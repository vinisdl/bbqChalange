using bbq.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace bbq.Domain.Entities
{
    public class BarbecueParticipant : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Contribuition { get; set; }

        public bool IsValid() => !string.IsNullOrEmpty(Name);

    }
}
