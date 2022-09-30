using Entities.Abstract;

namespace DataAccess.Abstract.Redis
{
    public interface IRedisGenericRepository<T> : IKeyValueGenericRepository<T> where T : class, IRedisEntity, new()
    {

    }
}
