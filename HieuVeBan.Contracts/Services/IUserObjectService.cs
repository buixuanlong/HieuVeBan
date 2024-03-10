using HieuVeBan.Models.DTOs;

namespace HieuVeBan.Contracts.Services
{
    public interface IUserObjectService
    {
        Task<IEnumerable<UserObjectModel>> GetUserObjectsAsync(CancellationToken cancellationToken = default);
    }
}
