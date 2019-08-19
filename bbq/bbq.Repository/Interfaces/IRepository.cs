using bbq.Domain.Entities.Base;
using System.Collections.Generic;
using System.Linq;

namespace bbq.Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T Add(T obj);
        void AddAll(IEnumerable<T> obj);
        void DeleteAll(IEnumerable<T> obj);
        void Delete(T obj);
        T First();
        IQueryable<T> Get();
        void Update(T obj);
        void Commit();
        T GetByKey(string searchKey);
    }
}