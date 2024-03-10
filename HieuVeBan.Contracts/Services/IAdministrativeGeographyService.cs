using HieuVeBan.Models.Commands.QueryParams;
using HieuVeBan.Models.DTOs;

namespace HieuVeBan.Contracts.Services
{
    public interface IAdministrativeGeographyService
    {
        Task<PagedList<ProvinceSummaryModel>> GetProvincesAsync(ProvinceQueryParams queryParams, CancellationToken cancellationToken = default);
    }
}
