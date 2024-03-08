using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public sealed class AppUser : BaseEntity<Guid>
    {
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string SecretKey { get; set; } = null!;
    }
}