using HieuVeBan.Abstraction.Interfaces;
using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class UserHistory : BaseEntity<Guid>, ICreatedDateTime
    {
        public DateTime CreatedDateTime { get; set; }
    }
}
