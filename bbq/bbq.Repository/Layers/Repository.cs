using bbq.Context;
using bbq.Domain.Entities.Base;
using bbq.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace bbq.Repository.Layers
{
    public abstract class MemoryRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly BBQContext Context;
        private DbSet<T> Entity => Context.Set<T>();

        public MemoryRepository(BBQContext ctx)
        {
            Context = ctx;
        }

        public T GetByKey(string searchKey)
        {
            var item = Entity.FirstOrDefault(f => f.SearchKey == searchKey);

            return item;
        }
    }
}