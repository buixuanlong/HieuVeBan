using HieuVeBan.Models.Abstractions.Entities;
using HieuVeBan.Models.Enum;

namespace HieuVeBan.Models.Entities
{
    public sealed class AppUser : BaseEntity<Guid>
    {
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public required UserType Type { get; set; }
        public string? SecretKey { get; set; }

        /// <summary>
        /// Base64 hashed
        /// </summary>
        public required string PasswordHash { get; set; }
    }
}