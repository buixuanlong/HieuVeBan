namespace HieuVeBan.Models.DTOs;

public class IdentityModel
{
    public required Guid UserId { get; set; }
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }
    public required string ClientId { get; set; }
    public required List<string> Scopes { get; set; } = [];
}
