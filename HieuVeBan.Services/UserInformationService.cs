using AutoMapper;
using AutoMapper.QueryableExtensions;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Data;
using HieuVeBan.Models.Commands;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HieuVeBan.Services
{
    public class UserInformationService : IUserInformationService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public UserInformationService(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public Task<UserInformationModel?> GetUserInformationByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => _applicationDbContext.Users
            .Where(x => x.Id == id)
            .ProjectTo<UserInformationModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        public Task<UserInformationModel?> GetUserInformationAsync(string search, CancellationToken cancellationToken = default)
        => _applicationDbContext.Users
            .Where(x => EF.Functions.Like(x.Phone, search) || EF.Functions.Like(x.Email, search))
            .ProjectTo<UserInformationModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        public async Task<Guid> CreateUserInformationAsync(UserInformationCreateModel model)
        {
            var newUserInfor = _mapper.Map<User>(model);
            _applicationDbContext.Users.Add(newUserInfor);
            await _applicationDbContext.SaveChangesAsync();

            return newUserInfor.Id;
        }
    }
}
