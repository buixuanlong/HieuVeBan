using Asp.Versioning;
using HieuVeBan.Abstraction.Security;
using HieuVeBan.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.Controllers
{
    [Authorize(Policy = SecurityConstant.Policies.ExternalPolicy)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user-objects")]
    public class UserObjectsController : Controller
    {
        private readonly IUserObjectService _userObjectService;

        public UserObjectsController(IUserObjectService userObjectService)
        {
            _userObjectService = userObjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserObjects(CancellationToken cancellationToken)
        {
            var res = await _userObjectService.GetUserObjectsAsync(cancellationToken);
            return Ok(res);
        }
    }
}
