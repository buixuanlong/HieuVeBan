using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class MBTIFunctionalFactorNameDetail : BaseEntity<Guid>
    {
        public string Character { get; set; } = null!;
        public int SortOrder { get; set; }
        public Guid ColorId { get; set; }
        public Color Color { get; set; } = null!;

        public Guid MBTIFunctionalFactorId { get; set; }
        public MBTIFunctionalFactor MBTIFunctionalFactor { get; set; } = null!;
    }
}
