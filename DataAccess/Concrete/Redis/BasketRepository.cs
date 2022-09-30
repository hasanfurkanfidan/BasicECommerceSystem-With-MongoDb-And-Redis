using DataAccess.Abstract.Redis;
using Entities.Concrete;

namespace DataAccess.Concrete.Redis
{
    public class BasketRepository : RedisGenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(RedisContext context) : base(context)
        {

        }
    }
}
