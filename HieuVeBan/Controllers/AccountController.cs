using HieuVeBan.Contracts.Services;
using HieuVeBan.Helpers;
using HieuVeBan.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HieuVeBan.Controllers
{
    //TODO: Refactor
    public class AccountController : Controller
    {
        private readonly IAdminService _adminService;
        public AccountController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Route("/login")]
        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return Redirect("/admin");
            }
            return RedirectToAction("LoginAdmin", "Account", new { returnUrl = "/" });
        }

        public IActionResult LoginAdmin(string? returnUrl = null)
        {
            string? uri = Url.Action("Login", "Account", new { returnUrl }, HttpContext.Request.Scheme, HttpContext.Request.Host.Value);

            return Redirect("http://login.ueh.edu.vn/?returnURL=" + uri);
        }

        public async Task<IActionResult> Login(string t)
        {
            try
            {
                string email = LoginUEHService.Login(t);
                if (email.Equals("error") || email.Trim() == "")
                {
                    return RedirectToAction("Login", "Account", new { returnUrl = "/admin" });
                }
                else
                {
                    var claims = new List<Claim>();
                    var isAdmin = _adminService.LoginAdmin(email);

                    if (isAdmin != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Name, isAdmin.HoTen));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, email));
                        claims.Add(new Claim(ClaimTypes.GivenName, isAdmin.MaQuanLy));
                        claims.Add(new Claim(ClaimTypes.Role, "admin"));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return Redirect("/admin");
                    }
                    else
                    {
                        return RedirectToAction("LoginAdmin", "Account", new { returnUrl = "/" });
                    }
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("LoginAdmin", "Account", new { returnUrl = "/" });
            }
        }

        //=====================qnp-login======================
        [Route("/login-ueh")]
        public IActionResult LoginUeh(string? returnUrl = null)
        {
            string? uri = Url.Action("LoginUehCallback", "Account", new { returnUrl }, HttpContext.Request.Scheme, HttpContext.Request.Host.Value);

            return Redirect("http://login.ueh.edu.vn/?returnURL=" + uri);
        }

        [HttpGet]
        public IActionResult LoginUehCallback(string t, string? returnUrl = null)
        {
            string email = LoginUEHService.Login(t);

            if (string.IsNullOrEmpty(email))
            {
                return NotFound();
            }
            return LocalRedirect(Url.GetLocalUrl(returnUrl ?? ""));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
