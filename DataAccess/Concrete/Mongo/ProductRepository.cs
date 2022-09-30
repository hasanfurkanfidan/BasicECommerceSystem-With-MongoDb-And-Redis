using CommonModels.Constants;
using Core.Utils.Settings;
using DataAccess.Abstract.Mongo;
using Entities.Concrete;

namespace DataAccess.Concrete.Mongo
{
    public class ProductRepository : MongoGenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MongoDbSettings dbSettings) : base(DatabaseConstants.MongoCollections.ProductCollection, dbSettings)
        {

        }
    }
}
