using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.QueryParam;

namespace HieuVeBan.Contracts.Services
{
    public interface IMethodService
    {
        Task<PagedList<MethodModel>> GetMethodsAsync(MethodQueryParams queryParams, CancellationToken cancellationToken = default);
        Task<MethodModel?> GetMethodAsync(Guid methodId, CancellationToken cancellationToken = default);
    }
}
