namespace HieuVeBan.Models.DTOs;

public class UserModel
{
    public required Guid UserId { get; init; }
    public required string UserName { get; init; }
    public required string UserEmail { get; init; }
}
