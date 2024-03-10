using Asp.Versioning;
using HieuVeBan.Abstraction.Security;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Models.Commands.QueryParams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.Controllers
{
    [Authorize(Policy = SecurityConstant.Policies.ExternalPolicy)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/methods")]
    public class MethodsController : Controller
    {
        private readonly IMethodService _personalityAssessmentMethodService;

        public MethodsController(IMethodService personalityAssessmentMethodService)
        {
            _personalityAssessmentMethodService = personalityAssessmentMethodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMethods([FromQuery] MethodQueryParams query, CancellationToken cancellationToken)
        {
            var res = await _personalityAssessmentMethodService.GetMethodsAsync(query, cancellationToken);
            return Ok(res);
        }

        [HttpGet("{methodId::guid}")]
        public async Task<IActionResult> GetMethod([FromRoute] Guid methodId, CancellationToken cancellationToken)
        {
            var res = await _personalityAssessmentMethodService.GetMethodAsync(methodId, cancellationToken);
            return Ok(res);
        }
    }
}
