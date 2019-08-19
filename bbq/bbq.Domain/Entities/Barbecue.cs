using bbq.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace bbq.Domain.Entities
{
    public class Barbecue : Entity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string AdditionalDescription { get; set; }
        public DateTimeOffset ScheduleDate { get; set; }

        public decimal SampleContribution { get; set; }
        public decimal SampleContributionWithoutDrink { get; set; }
        public List<BarbecueParticipant> BarbecueParticipants { get; set; }
        public override string SearchKey => Description;

        public bool IsValid() => !string.IsNullOrEmpty(Description) && ScheduleDate != null && ScheduleDate != DateTimeOffset.MinValue;
    }
}
