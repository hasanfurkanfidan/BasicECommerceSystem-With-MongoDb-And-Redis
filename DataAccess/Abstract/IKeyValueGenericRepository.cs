using Entities.Abstract;

namespace DataAccess.Abstract
{
    public interface IKeyValueGenericRepository<T> where T : class, IEntity, new()
    {
        Task<T> Get(string key);
        Task Delete(string key);
        Task SaveOrUpdate(T entity,string key);
    }
}
