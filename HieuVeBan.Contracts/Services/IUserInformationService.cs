using HieuVeBan.Models.Commands;
using HieuVeBan.Models.DTOs;

namespace HieuVeBan.Contracts.Services
{
    public interface IUserInformationService
    {
        Task<UserInformationModel?> GetUserInformationByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<UserInformationModel?> GetUserInformationAsync(string search, CancellationToken cancellationToken = default);
        Task<Guid> CreateUserInformationAsync(UserInformationCreateModel model);
    }
}
