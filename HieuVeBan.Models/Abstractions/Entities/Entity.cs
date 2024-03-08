using HieuVeBan.Abstraction.Interfaces;

namespace HieuVeBan.Models.Abstractions.Entities;

public abstract class Entity<EntityId> : IEntity<EntityId>
{
    public required EntityId Id { get; set; }
}