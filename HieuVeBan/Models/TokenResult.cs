using System.Text.Json.Serialization;

namespace HieuVeBan.Models;

public record TokenResult
{
    [JsonPropertyName("access_token")]
    public required string Token { get; init; }

    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; init; }
}