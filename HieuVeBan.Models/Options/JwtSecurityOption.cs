namespace HieuVeBan.Models.Options;

public class JwtSecurityOption
{
    public static readonly string SectionKey = "JwtSecurity";

    public required string ValidAudience { get; init; }
    public required string ValidIssuer { get; init; }
    public required string Secret { get; init; }
    public required int DefaultExpirationTimeInSecond { get; init; } = 30 * 60;
}