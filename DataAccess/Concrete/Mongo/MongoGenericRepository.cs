using Core.Utils.Settings;
using DataAccess.Abstract.Mongo;
using Entities.Abstract;
using MongoDB.Driver;

namespace DataAccess.Concrete.Mongo
{
    public class MongoGenericRepository<T> : IMongoGenericRepository<T> where T : class, IMongoEntity, new()
    {
        private readonly IMongoCollection<T> _collection;
        public MongoGenericRepository(string collectionName, MongoDbSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = database.GetCollection<T>(collectionName);
        }
        public async Task<T> Create(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            await _collection.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public async Task<List<T>> GetAll()
        {
            var entities = await _collection.Find(entity => true).ToListAsync();
            return entities;
        }

        public async Task<T> GetById(string id)
        {
            var entity = await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            await _collection.FindOneAndReplaceAsync(p => p.Id == entity.Id, entity);
            return entity;
        }
    }
}
