using bbq.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bbq.Repository.Interfaces
{
    public interface IBarbecueRepository : IRepository<Barbecue>
    {
        Barbecue GetById(int id);
    }
}
