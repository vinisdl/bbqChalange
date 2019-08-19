using bbq.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bbq.Context
{
    public class BBQContext : DbContext

    {
        public DbSet<User> Users { get; set; }
        public DbSet<Barbecue> Barbecues { get; set; }
        public DbSet<BarbecueParticipant> BarbecueParticipants { get; set; }
        public BBQContext(DbContextOptions options)
           : base(options)
        {
        }
    }
}
