namespace HieuVeBan.Models.Options;

public sealed class SecurityOptions
{
    public static readonly string SectionKey = "Security";

    public required string PasswordHash { get; set; }
}