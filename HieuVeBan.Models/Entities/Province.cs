using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class Province : BaseEntity<int>
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? NameEn { get; set; }
        public string FullName { get; set; } = null!;
        public string? FullNameEn { get; set; }
        public string? CodeName { get; set; }

        public int? AdministrativeRegionId { get; set; }
        public int? AdministrativeUnitId { get; set; }

        public AdministrativeRegion? AdministrativeRegion { get; set; }
        public AdministrativeUnit? AdministrativeUnit { get; set; }
    }
}
