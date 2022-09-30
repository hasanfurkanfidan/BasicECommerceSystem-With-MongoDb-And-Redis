using DataAccess.Abstract.Redis;
using Entities.Abstract;
using System.Text.Json;

namespace DataAccess.Concrete.Redis
{
    public class RedisGenericRepository<T> : IRedisGenericRepository<T> where T : class, IRedisEntity, new()
    {
        private readonly RedisContext _redisContext;
        public RedisGenericRepository(RedisContext redisContext)
        {
            _redisContext = redisContext;
        }

        public async Task Delete(string key)
        {
            await _redisContext.GetDb().KeyDeleteAsync(key);
        }

        public async Task<T> Get(string key)
        {
            var existData = await _redisContext.GetDb().StringGetAsync(key);
            if (existData.IsNull)
                return null;

            var data = JsonSerializer.Deserialize<T>(existData);
            return data;
        }

        public async Task SaveOrUpdate(T entity, string key)
        {
            await _redisContext.GetDb().StringSetAsync(key, JsonSerializer.Serialize(entity));
        }
    }
}
