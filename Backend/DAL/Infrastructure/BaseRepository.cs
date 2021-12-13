using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Infrastructure
{
    public class BaseRepository<Entity, TContext> : IRepository<Entity, TContext>
        where Entity : EntityBase, new()
        where TContext : DbContext, IdbContext<Entity>
    {
        private readonly IDbContextFactory<TContext> contextFactory;
        private readonly TContext dbContext;
        public BaseRepository(IDbContextFactory<TContext> contextFactory)
        {
            this.contextFactory = contextFactory;
            dbContext = contextFactory.CreateDbContext();
        }

        public void DeleteEntity(Guid entityId)
        {
            var entity = (Entity)Activator.CreateInstance(typeof(Entity));
            entity.Id = entityId;
            dbContext.Attach(entity);
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public Entity GetEntityById(Guid entityId)
        {
            return dbContext.Entities.Where(x => x.Id == entityId).FirstOrDefault();
        }

        public IEnumerable<Entity> GetEntities()
        {
            return dbContext.Entities;
        }

        public void InsertEntity(Entity entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void UpdateEntity(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
