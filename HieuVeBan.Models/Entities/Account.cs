using HieuVeBan.Models.Abstractions.Entities;
using HieuVeBan.Models.Enum;

namespace HieuVeBan.Models.Entities
{
    public class Account : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Role Role { get; set; }
    }
}
