using bbq.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bbq.Context
{
    public class BBQContext : DbContext

    {
        public DbSet<User> Users { get; set; }
        public BBQContext(DbContextOptions options)
           : base(options)
        {
        }
    }
}
