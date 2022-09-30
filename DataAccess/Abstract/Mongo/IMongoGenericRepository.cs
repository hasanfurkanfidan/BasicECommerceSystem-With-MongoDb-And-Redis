using Entities.Abstract;

namespace DataAccess.Abstract.Mongo
{
    public interface IMongoGenericRepository<T> : IGenericRepository<T> where T : class, IMongoEntity, new()
    {
    }
}
