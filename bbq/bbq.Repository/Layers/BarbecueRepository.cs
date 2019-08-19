using bbq.Context;
using bbq.Domain.Entities;
using bbq.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bbq.Repository.Layers
{
    public class BarbecueRepository : MemoryRepository<Barbecue>, IBarbecueRepository
    {
        public BarbecueRepository(BBQContext ctx) : base(ctx)
        {
           
        }
        public Barbecue GetById(int id)
        {
            return Entity.Include(a => a.BarbecueParticipants).FirstOrDefault(a => a.Id == id);
        }
    }
}
