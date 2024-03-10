namespace HieuVeBan.Models.Commands
{
    public record UserInformationCreateModel
    {
        public string Name { get; init; } = null!;
        public DateTime Dob { get; init; }
        public string Email { get; init; } = null!;
        public string? Phone { get; init; } = null!;
        public string Thpt { get; init; } = null!;
        public int ProvinceId { get; init; }
        public Guid UserObjectId { get; init; }
    }
}
