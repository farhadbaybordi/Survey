using Microsoft.EntityFrameworkCore;

namespace DAL.Infrastructure
{
    public interface IdbContext<Entity>
        where Entity : EntityBase
    {
        public DbSet<Entity> Entities { get; set; }
    }
}
