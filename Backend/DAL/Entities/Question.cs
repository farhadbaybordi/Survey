using DAL.Infrastructure;
using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Question : EntityBase
    {
        public string Description { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
