using DAL.Configuration;
using DAL.Entities;
using DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class AnswerContext : DbContext, IdbContext<Answer>
    {
        public DbSet<Answer> Entities { get; set; }

        public AnswerContext(DbContextOptions<AnswerContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
