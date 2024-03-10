using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.QueryParam;

namespace HieuVeBan.Contracts.Services
{
    public interface IAdministrativeGeographyService
    {
        Task<PagedList<ProvinceSummaryModel>> GetProvincesAsync(ProvinceQueryParams queryParams, CancellationToken cancellationToken = default);
    }
}
