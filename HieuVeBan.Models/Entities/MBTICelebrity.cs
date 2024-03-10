using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class MBTICelebrity : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageLink { get; set; } = null!;
        public Guid PersonalityGroupId { get; set; }
        public MBTIPersonalityGroup PersonalityGroup { get; set; } = null!;
    }
}
