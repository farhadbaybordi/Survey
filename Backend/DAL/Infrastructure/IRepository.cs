using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DAL.Infrastructure
{
    public interface IRepository<Entity, TContext>
        where Entity : class, new()
        where TContext : DbContext
    {
        Entity GetEntityById(Guid entityId);
        IEnumerable<Entity> GetEntities();
        void InsertEntity(Entity entity);
        void DeleteEntity(Guid entityId);
        void UpdateEntity(Entity entity);
    }
}
