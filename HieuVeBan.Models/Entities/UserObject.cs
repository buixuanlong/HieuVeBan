using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class UserObject : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public int SortOrder { get; set; }
    }
}