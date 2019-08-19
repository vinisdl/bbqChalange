using bbq.Domain.Entities.Base;

namespace bbq.Repository.Interfaces
{
    public interface IRepository<out T> where T : Entity
    {
        T GetByKey(string searchKey);
    }
}