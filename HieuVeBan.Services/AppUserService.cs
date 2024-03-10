using AutoMapper;
using HieuVeBan.Abstraction.Security;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Data;
using HieuVeBan.Models.Abstractions;
using HieuVeBan.Models.Commands.QueryParams;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;
using HieuVeBan.Models.Options;
using HieuVeBan.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HieuVeBan.Services;

class AppUserService(
    ApplicationDbContext applicationDbContext,
    IOptions<SecurityOptions> options,
    IMapper mapper) : IAppUserService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
    private readonly string _passwordHash = options.Value.PasswordHash;
    private readonly IMapper _mapper = mapper;


    public Task<PagedList<UserModel>> GetUsersAsync(UserQueryParams queryParams, CancellationToken cancellationToken = default)
    {
        var query = _applicationDbContext.AppUsers.AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryParams.Search))
            query = query.ContainWithCollation(x => x.UserName, queryParams.Search);

        query = query.OrderBy(x => x.UserName);

        return query.ToPagedListAsync<AppUser, UserModel>(queryParams, _mapper.ConfigurationProvider, cancellationToken);
    }

    public async Task<Result<Guid>> CreateAsync(string userName, string email, string password, CancellationToken cancellationToken = default)
    {
        if (await _applicationDbContext.AppUsers
           .AnyAsync(x => x.UserName == userName
               || x.UserEmail == email, cancellationToken))
        {

            return Result.Failure<Guid>(UserErrors.AlreadyExists);
        }

        var user = new AppUser
        {
            Id = Guid.Empty,
            UserName = userName,
            UserEmail = email,
            Type = Models.Enum.UserType.External,
            PasswordHash = await password.EncryptToBase64StringAsync(_passwordHash)
        };

        await _applicationDbContext.AppUsers.AddAsync(user, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(user.Id);
    }

    public async Task<Result> ChangePasswordAsync(Guid userId, string password, string newPassword, CancellationToken cancellationToken = default)
    {
        var user = await _applicationDbContext.AppUsers.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
        if (user is null)
            return Result.Failure<IdentityModel>(Error.NotFound);

        var passwordHashed = await password.EncryptToBase64StringAsync(_passwordHash);

        if (!user.PasswordHash.Equals(passwordHashed))
            return Result.Failure<IdentityModel>(UserErrors.InvalidPassword);

        var pwd = await newPassword.EncryptToBase64StringAsync(_passwordHash);

        user.PasswordHash = pwd;

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<IdentityModel>> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        // TODO: Caching user
        var user = await _applicationDbContext.AppUsers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        if (user is null)
            return Result.Failure<IdentityModel>(Error.NotFound);

        var passwordHashed = await password.EncryptToBase64StringAsync(_passwordHash);
        if (!user.PasswordHash.Equals(passwordHashed))
            return Result.Failure<IdentityModel>(UserErrors.InvalidPassword);

        var res = _mapper.Map<IdentityModel>(user);

        if (user.Type == Models.Enum.UserType.Internal)
            res.Scopes.Add(SecurityConstant.Scopes.Internal);

        if (user.Type == Models.Enum.UserType.External)
            res.Scopes.Add(SecurityConstant.Scopes.External);

        res.ClientId = SecurityConstant.Client.AppClient;

        return Result.Success(res);
    }
}

public static class UserErrors
{
    public static Error InvalidPassword = new("User.InvalidPassword", "Invalid password. Please check your password and try again");
    public static Error AlreadyExists = new("User.AlreadyExists", "User already exists");

}