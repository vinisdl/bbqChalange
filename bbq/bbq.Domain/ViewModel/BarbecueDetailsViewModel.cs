using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bbq.Domain.ViewModel
{
    public class BarbecueDetailsViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset ScheduleDate { get; set; }
        public decimal SampleContribution { get; set; }
        public decimal SampleContributionWithoutDrink { get; set; }
        public List<BarbecueParticipantViewModel> BarbecueParticipants { get; set; }

        public decimal Total => BarbecueParticipants.Sum(bp => bp.Contribuition);
        public decimal RecommendingContribution => Total / BarbecueParticipants.Count;

    }
}
