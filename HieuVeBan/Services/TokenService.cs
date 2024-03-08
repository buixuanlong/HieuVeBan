using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HieuVeBan.Helpers;
using HieuVeBan.Models;
using HieuVeBan.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HieuVeBan.Services;

public class TokenService(
    TimeProvider timeProvider,
    IOptions<JwtSecurityOption> option) : ITokenService
{
    private readonly JwtSecurityOption _jwtSecurityOption = option.Value ?? throw new ArgumentException(nameof(JwtSecurityOption));
    private readonly TimeProvider _timeProvider = timeProvider;

    public Task<TokenResult> GenerateTokenAsync(
        IdentityModel identityModel,
        TimeSpan? expirationTime = null,
        CancellationToken cancellationToken = default)
    {
        expirationTime ??= TimeSpan.FromSeconds(_jwtSecurityOption.DefaultExpirationTimeInSecond);

        var now = _timeProvider.GetUtcNow().UtcDateTime;
        var expires = now.Add((TimeSpan)expirationTime);
        var signinCredentials = SigningCredentialsHelper.BuildCredentialsSha256(_jwtSecurityOption.Secret);
        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, identityModel.UserId.ToString()),
            new(JwtRegisteredClaimNames.Nbf, ConvertToUnixTimestamp(now).ToString(), ClaimValueTypes.Integer),
            new(JwtRegisteredClaimNames.Iat, ConvertToUnixTimestamp(now).ToString(), ClaimValueTypes.Integer),
            new(JwtRegisteredClaimNames.Amr, "pwd"), // password
            new("user_name", identityModel.UserName),
            new("user_email", identityModel.UserEmail),
            new("client_id", identityModel.ClientId),
        };

        claims.AddRange(identityModel.Scopes.Select(x => new Claim("scope", x)));

        var tokeOptions = new JwtSecurityToken(
            issuer: _jwtSecurityOption.ValidIssuer,
            audience: _jwtSecurityOption.ValidAudience,
            claims: claims,
            expires: expires,
            signingCredentials: signinCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

        return Task.FromResult(new TokenResult
        {
            Token = tokenString,
            ExpiresIn = (int)expirationTime.Value.TotalSeconds
        });
    }

    private static long ConvertToUnixTimestamp(DateTime dateTime)
    {
        return (long)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }
}