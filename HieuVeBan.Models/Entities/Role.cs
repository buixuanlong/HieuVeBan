using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class Role : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
    }
}
