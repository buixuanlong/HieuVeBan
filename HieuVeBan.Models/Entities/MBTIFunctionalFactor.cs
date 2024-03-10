using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class MBTIFunctionalFactor : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public Guid MBTIDichotomousPairId { get; set; }
        public MBTIDichotomousPair MBTIDichotomousPair { get; set; } = null!;

        public virtual ICollection<MBTIFunctionalFactorNameDetail> MBTIFunctionalFactorNameDetails { get; set; } = new List<MBTIFunctionalFactorNameDetail>();
    }
}
