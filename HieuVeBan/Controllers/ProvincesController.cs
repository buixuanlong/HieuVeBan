using Asp.Versioning;
using HieuVeBan.Abstraction.Security;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Models.QueryParam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.Controllers
{
    [Authorize(Policy = SecurityConstant.Policies.ExternalPolicy)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/provinces")]
    public class ProvincesController : Controller
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
