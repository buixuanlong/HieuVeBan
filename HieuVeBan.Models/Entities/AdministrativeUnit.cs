using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class AdministrativeUnit : BaseEntity<int>
    {
        public string? FullName { get; set; }
        public string? FullNameEn { get; set; }
        public string? ShortName { get; set; }
        public string? ShortNameEn { get; set; }
        public string? CodeName { get; set; }
        public string? CodeNameEn { get; set; }
    }
}
