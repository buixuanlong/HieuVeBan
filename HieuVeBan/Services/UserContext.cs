
using System.Security.Claims;
using HieuVeBan.Abstraction.Interfaces;

namespace HieuVeBan.Services;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid GetUserId()
    {
        if (_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false)
        {
            _ = Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);
            return userId;
        }

        return Guid.Empty;
    }

    public string GetEmail()
    {
        if (_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false)
            return _httpContextAccessor.HttpContext?.User.FindFirstValue("user_email") ?? string.Empty;

        return string.Empty;
    }
}
