using Asp.Versioning;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Models.Commands.QueryParams;
using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/provinces")]
    public class ProvincesController : BaseApiController
    {
        private readonly IAdministrativeGeographyService _administrativeGeographyService;

        public ProvincesController(IAdministrativeGeographyService administrativeGeographyService)
        {
            _administrativeGeographyService = administrativeGeographyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProvinces([FromQuery] ProvinceQueryParams query, CancellationToken cancellationToken)
        {
            var res = await _administrativeGeographyService.GetProvincesAsync(query, cancellationToken);
            return Ok(res);
        }
    }
}
