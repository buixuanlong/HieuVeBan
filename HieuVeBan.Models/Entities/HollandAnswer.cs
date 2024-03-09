using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class HollandAnswer : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string? ShortName { get; set; }
        public int Mark { get; set; }
    }
}
