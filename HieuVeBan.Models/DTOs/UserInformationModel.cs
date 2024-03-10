namespace HieuVeBan.Models.DTOs
{
    public class UserInformationModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Email { get; set; } = null!;
        public string? Phone { get; set; } = null!;
        public string Thpt { get; set; } = null!;

        public ProvinceModel Province { get; set; } = null!;
        public UserObjectModel UserObject { get; set; } = null!;
    }
}
