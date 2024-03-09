using HieuVeBan.Models;
using HieuVeBan.Models.DTOs;

namespace HieuVeBan.Services;

public interface ITokenService
{
    Task<TokenResult> GenerateTokenAsync(IdentityModel identityModel, TimeSpan? expirationTime = null, CancellationToken cancellationToken = default);
}