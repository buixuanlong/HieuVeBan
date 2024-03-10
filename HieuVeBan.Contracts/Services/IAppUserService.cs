using HieuVeBan.Models.Abstractions;
using HieuVeBan.Models.Commands.QueryParams;
using HieuVeBan.Models.DTOs;

namespace HieuVeBan.Contracts.Services;

public interface IAppUserService
{
    Task<PagedList<UserModel>> GetUsersAsync(UserQueryParams queryParams, CancellationToken cancellationToken = default);

    Task<Result<Guid>> CreateAsync(
        string userName,
        string email,
        string password,
        CancellationToken cancellationToken = default);
    Task<Result> ChangePasswordAsync(Guid userId, string password, string newPassword, CancellationToken cancellationToken = default);
    Task<Result<IdentityModel>> LoginAsync(string username, string password, CancellationToken cancellationToken = default);
}