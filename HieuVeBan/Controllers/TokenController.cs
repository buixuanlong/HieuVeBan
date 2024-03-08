using HieuVeBan.Abstraction.Interfaces;
using HieuVeBan.Configurations;
using HieuVeBan.Models;
using HieuVeBan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class UsersController(ITokenService tokenService) : Controller
    {
        private readonly ITokenService _tokenService = tokenService;

        [AllowAnonymous]
        public async Task<IActionResult> RequestToken(
            [FromForm] LoginModel model,
            CancellationToken cancellationToken)
        {
            if (model.UserName == "phongnd" && model.Password == "123456")
            {
                var res = await _tokenService.GenerateTokenAsync(new IdentityModel
                {
                    UserId = Guid.NewGuid(),
                    UserName = model.UserName,
                    UserEmail = "phongnd.dev@gmail.com",
                    ClientId = Guid.NewGuid().ToString(),
                    Scopes = ["external", "api"]
                }, cancellationToken: cancellationToken);

                return Ok(res);
            }

            return BadRequest(model);
        }
    }

    public record LoginModel(string UserName, string Password);
}
