using bbq.Context;
using bbq.Domain.Entities;
using bbq.Repository.Interfaces;

namespace bbq.Repository.Layers
{
    public class UserMemoryRepository : MemoryRepository<User>, IUserRepository
    {
        public UserMemoryRepository(BBQContext ctx) : base(ctx)
        {
        }
    }
}