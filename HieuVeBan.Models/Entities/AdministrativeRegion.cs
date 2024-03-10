using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class AdministrativeRegion : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string? CodeName { get; set; }
        public string? CodeNameEn { get; set; }
    }
}
