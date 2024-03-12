using HieuVeBan.Abstraction.Interfaces;
using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class User : BaseEntity<Guid>, ICreatedDateTime
    {
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Email { get; set; } = null!;
        public string? Phone { get; set; } = null!;
        public string Thpt { get; set; } = null!;
        public int ProvinceId { get; set; }
        public Guid UserObjectId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Province Province { get; set; } = null!;
        public UserObject UserObject { get; set; } = null!;
    }
}
