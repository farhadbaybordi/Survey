using DAL.Infrastructure;
using System;

namespace DAL.Entities
{
    public class Answer: EntityBase
    {
        public Guid ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }

        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public int AnswerValue { get; set; }
    }
}
