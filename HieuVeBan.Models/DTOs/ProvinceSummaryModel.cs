namespace HieuVeBan.Models.DTOs
{
    public class ProvinceSummaryModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? NameEn { get; set; }
        public string FullName { get; set; } = null!;
        public string? FullNameEn { get; set; }
        public string? CodeName { get; set; }
    }
}
