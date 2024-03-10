using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class MBTIDichotomousPair : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
    }
}
