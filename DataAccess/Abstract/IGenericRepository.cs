using Entities.Abstract;

namespace DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
    }
}
