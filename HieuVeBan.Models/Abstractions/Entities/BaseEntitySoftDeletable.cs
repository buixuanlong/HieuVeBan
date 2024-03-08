
using HieuVeBan.Abstraction.Interfaces;

namespace HieuVeBan.Models.Abstractions.Entities;

public abstract class BaseEntitySoftDeletable<EntityId> : Entity<EntityId>, ISoftDeletable
{
    public bool IsDeleted { get; set; }
}