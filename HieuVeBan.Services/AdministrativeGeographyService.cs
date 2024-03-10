using AutoMapper;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Data;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;
using HieuVeBan.Models.QueryParam;
using HieuVeBan.Services.Extensions;

namespace HieuVeBan.Services
{
    public class AdministrativeGeographyService : IAdministrativeGeographyService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public AdministrativeGeographyService(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public Task<PagedList<ProvinceSummaryModel>> GetProvincesAsync(ProvinceQueryParams queryParams, CancellationToken cancellationToken = default)
        {
            var query = _applicationDbContext.Provinces.AsQueryable();

            if (queryParams.AdministrativeRegionId is not null)
                query = query.Where(x => x.AdministrativeRegionId == queryParams.AdministrativeRegionId);

            if (queryParams.AdministrativeUnitId is not null)
                query = query.Where(x => x.AdministrativeUnitId == queryParams.AdministrativeUnitId);

            if (!string.IsNullOrWhiteSpace(queryParams.Search))
                query = query.ContainWithCollation(x => x.FullName, queryParams.Search);

            query = query.OrderBy(x => x.Id);

            return query.ToPagedListAsync<Province, ProvinceSummaryModel>(queryParams, _mapper.ConfigurationProvider, cancellationToken);
        }
    }
}
