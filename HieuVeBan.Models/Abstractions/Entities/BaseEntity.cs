using HieuVeBan.Abstraction.Interfaces;

namespace HieuVeBan.Models.Abstractions.Entities;

public abstract class BaseEntity<EntityId> : Entity<EntityId>, ICreatedDateTime, ICreatedUserId, IModificationHistory, IConcurrencyCheck
{
    public DateTime CreatedDateTime { get; set; }
    public Guid CreatedUserId { get; set; }
    public DateTime? UpdatedDateTime { get; set; }
    public Guid? UpdatedUserId { get; set; }
}