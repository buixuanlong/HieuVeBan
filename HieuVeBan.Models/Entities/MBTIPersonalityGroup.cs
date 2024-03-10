using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class MBTIPersonalityGroup : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
