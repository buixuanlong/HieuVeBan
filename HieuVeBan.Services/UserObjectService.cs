using AutoMapper;
using AutoMapper.QueryableExtensions;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Data;
using HieuVeBan.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HieuVeBan.Services
{
    public class UserObjectService : IUserObjectService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public UserObjectService(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserObjectModel>> GetUserObjectsAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.UserObjects
                    .OrderBy(x => x.SortOrder)
                    .ProjectTo<UserObjectModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
        }
    }
}
