using HieuVeBan.Models.Commands.QueryParams;
using HieuVeBan.Models.DTOs;

namespace HieuVeBan.Contracts.Services
{
    public interface IMethodService
    {
        Task<PagedList<MethodModel>> GetMethodsAsync(MethodQueryParams queryParams, CancellationToken cancellationToken = default);
        Task<MethodModel?> GetMethodAsync(Guid methodId, CancellationToken cancellationToken = default);
    }
}
