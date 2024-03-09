using Asp.Versioning;
using HieuVeBan.Abstraction.Security;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Models.QueryParam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace HieuVeBan.Controllers
{
    [Authorize(Policy = SecurityConstant.Policies.InternalPolicy)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/accounts")]
    public class AccountController(IAppUserService appUserService) : Controller
    {
        private readonly IAppUserService _appUserService = appUserService;

        [HttpGet]
        public async Task<IActionResult> ChangePassword([FromQuery] UserQueryParams query, CancellationToken cancellationToken)
        {
            var res = await _appUserService.GetUsersAsync(query, cancellationToken);

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] CreateModel model)
        {
            var res = await _appUserService.CreateAsync(model.UserName, model.UserEmail, model.Password);

            if (res.IsFailure)
                return BadRequest(new { Message = res.Error.Name });

            return Accepted(new { UserId = res.Value });
        }

        [HttpPost("{userId::guid}/change-password")]
        public async Task<IActionResult> ChangePassword(
            [FromRoute] Guid userId,
            [FromBody] ChangePasswordModel model)
        {
            var res = await _appUserService.ChangePasswordAsync(userId, model.Password, model.NewPassword);

            if (res.IsFailure)
                return BadRequest(new { Message = res.Error.Name });

            return Accepted();
        }

        public record CreateModel(string UserName, string UserEmail, string Password);
        public record ChangePasswordModel(string Password, string NewPassword);
    }
}
