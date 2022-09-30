using Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Concrete
{
    public class Product : IMongoEntity
    {
        [BsonId]
        public string Id { get ; set ; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
