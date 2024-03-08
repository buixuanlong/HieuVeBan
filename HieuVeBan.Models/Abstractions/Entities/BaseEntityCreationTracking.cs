using HieuVeBan.Abstraction.Interfaces;

namespace HieuVeBan.Models.Abstractions.Entities;

public abstract class BaseEntityCreationTracking<EntityId> : Entity<EntityId>, ICreatedDateTime, ICreatedUserId
{
    public DateTime CreatedDateTime { get; set; }
    public Guid CreatedUserId { get; set; }
}