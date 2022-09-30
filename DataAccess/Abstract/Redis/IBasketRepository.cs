using Entities.Concrete;

namespace DataAccess.Abstract.Redis
{
    public interface IBasketRepository : IRedisGenericRepository<Basket>
    {
    }
}
