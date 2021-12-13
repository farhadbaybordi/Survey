using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answer");
            builder
                .Property(a => a.Id)
                .HasDefaultValueSql("NEWID()");
            builder
                .HasKey(a => a.Id);
            builder
                .HasOne<Participant>()
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.ParticipantId);
            builder
                .HasOne<Question>()
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.QuestionId);
        }
    }
}
