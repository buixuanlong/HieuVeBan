using Asp.Versioning;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/token")]
    public class UsersController(
        IAppUserService appUserService,
        ITokenService tokenService) : Controller
    {
        private readonly IAppUserService _appUserService = appUserService;
        private readonly ITokenService _tokenService = tokenService;

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RequestToken(
            [FromForm] LoginModel model,
            CancellationToken cancellationToken)
        {
            var ur = await _appUserService.LoginAsync(model.UserName, model.Password, cancellationToken);
            if (ur.IsFailure)
                return BadRequest(new { Message = ur.Error.Name });

            var tokenRes = await _tokenService.GenerateTokenAsync(ur.Value, cancellationToken: cancellationToken);
            return Ok(tokenRes);
        }
    }

    public record LoginModel(string UserName, string Password);
}
