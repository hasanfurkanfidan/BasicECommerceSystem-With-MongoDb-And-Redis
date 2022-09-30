using Entities.Concrete;

namespace DataAccess.Abstract.Mongo
{
    public interface IProductRepository : IMongoGenericRepository<Product>
    {

    }
}
