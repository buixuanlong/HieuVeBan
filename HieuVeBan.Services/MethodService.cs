using AutoMapper;
using AutoMapper.QueryableExtensions;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Data;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;
using HieuVeBan.Models.QueryParam;
using HieuVeBan.Services.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HieuVeBan.Services
{
    public class MethodService : IMethodService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public MethodService(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public Task<PagedList<MethodModel>> GetMethodsAsync(MethodQueryParams queryParams, CancellationToken cancellationToken = default)
        {
            var query = _applicationDbContext.PersonalityAssessmentMethods.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryParams.Search))
                query = query.ContainWithCollation(x => x.Name, queryParams.Search);

            query = query.OrderBy(x => x.Name);

            return query.ToPagedListAsync<PersonalityAssessmentMethod, MethodModel>(queryParams, _mapper.ConfigurationProvider, cancellationToken);
        }

        public Task<MethodModel?> GetMethodAsync(Guid methodId, CancellationToken cancellationToken = default)
        => _applicationDbContext.PersonalityAssessmentMethods
            .Where(x => x.Id == methodId)
            .ProjectTo<MethodModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

    }
}
