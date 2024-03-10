using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class Color : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
