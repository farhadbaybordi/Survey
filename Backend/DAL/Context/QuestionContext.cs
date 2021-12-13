using DAL.Configuration;
using DAL.Entities;
using DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class QuestionContext : DbContext, IdbContext<Question>
    {
        public DbSet<Question> Entities { get; set; }

        public QuestionContext(DbContextOptions<QuestionContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
