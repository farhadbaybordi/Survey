using DAL.Configuration;
using DAL.Entities;
using DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ParticipantContext : DbContext, IdbContext<Participant>
    {
        public DbSet<Participant> Entities { get ; set ; }

        public ParticipantContext(DbContextOptions<ParticipantContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
