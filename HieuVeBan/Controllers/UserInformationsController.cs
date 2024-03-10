using Asp.Versioning;
using HieuVeBan.Abstraction.Security;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Models.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.Controllers
{
    [Authorize(Policy = SecurityConstant.Policies.ExternalPolicy)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user-informations")]
    public class UserInformationsController : Controller
    {
        private readonly IUserInformationService _userInformationService;

        public UserInformationsController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }

        [HttpGet("{id::guid}")]
        [ActionName(nameof(GetUserInformation))]
        public async Task<IActionResult> GetUserInformation(Guid id, CancellationToken cancellationToken)
        {
            var res = await _userInformationService.GetUserInformationByIdAsync(id, cancellationToken);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInformation(
            [FromQuery(Name = "search")] string search,
            CancellationToken cancellationToken)
        {
            var res = await _userInformationService.GetUserInformationAsync(search, cancellationToken);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserInformation([FromBody] UserInformationCreateModel model,
            CancellationToken cancellationToken)
        {
            var res = await _userInformationService.CreateUserInformationAsync(model);
            return CreatedAtAction(
                nameof(GetUserInformation),
                new { id = res },
                await _userInformationService.GetUserInformationByIdAsync(res, cancellationToken));
        }
    }
}
