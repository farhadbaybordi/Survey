using DAL.Infrastructure;
using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Participant : EntityBase
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
