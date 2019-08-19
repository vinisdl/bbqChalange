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

        protected DbSet<T> Entity => Context.Set<T>();

        public MemoryRepository(BBQContext ctx)
        {
            Context = ctx;
        }

        public T GetByKey(string searchKey)
        {
            var item = Entity.FirstOrDefault(f => f.SearchKey == searchKey);

            return item;
        }

        public virtual T Add(T obj)
        {
            return Entity.Add(obj).Entity;
        }

        public virtual void AddAll(IEnumerable<T> obj)
        {
            Entity.AddRange(obj);
        }

        public virtual void DeleteAll(IEnumerable<T> obj)
        {
            foreach (var entity in obj)
                Delete(entity);
        }

        public virtual void Delete(T obj)
        {
            Delete(obj);
        }

        public virtual T First()
        {
            return Get().FirstOrDefault();
        }

        public virtual IQueryable<T> Get()
        {
            return Entity;
        }

        public virtual void Update(T obj)
        {
            Context.Update(obj);
        }
        public virtual void Commit()
        {

            Context.SaveChanges();

        }

    }
}