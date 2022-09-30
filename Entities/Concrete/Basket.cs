using Entities.Abstract;

namespace Entities.Concrete
{
    public class Basket : IRedisEntity
    {
        public string UserName { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
