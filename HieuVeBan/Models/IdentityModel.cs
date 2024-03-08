using System.Text.Json.Serialization;

namespace HieuVeBan.Models;

public class IdentityModel
{
    public required Guid UserId { get; set; }
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }
    public required string ClientId { get; set; }
    public required List<string> Scopes { get; set; } = [];
}

public record TokenResult
{
    [JsonPropertyName("access_token")]
    public required string Token { get; init; }

    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; init; }
}