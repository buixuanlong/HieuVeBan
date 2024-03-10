namespace HieuVeBan.Models.DTOs
{
    public class ProvinceModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string? CodeName { get; set; }
        public string Name { get; set; } = null!;
        public string? NameEn { get; set; }
        public string FullName { get; set; } = null!;
        public string? FullNameEn { get; set; }
    }
}
