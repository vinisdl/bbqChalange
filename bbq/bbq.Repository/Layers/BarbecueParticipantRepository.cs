using bbq.Context;
using bbq.Domain.Entities;
using bbq.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace bbq.Repository.Layers
{
    public class BarbecueParticipantRepository : MemoryRepository<BarbecueParticipant>, IBarbecueParticipantRepository
    {
        public BarbecueParticipantRepository(BBQContext ctx) : base(ctx)
        {
        }
    }
}
