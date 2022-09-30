using CommonModels.Settings;
using Core.Utils.Settings;
using DataAccess.Abstract.Mongo;
using DataAccess.Abstract.Redis;
using DataAccess.Concrete.Mongo;
using DataAccess.Concrete.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DataAccess.DependencyResolvers
{
    public static class DataAccessModule
    {
        public static void Load(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoConfiguration = configuration.GetSection("MongoConfig");
            services.Configure<MongoDbSettings>(mongoConfiguration);
            services.AddSingleton(options => options.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            var redisConfiguration = configuration.GetSection("RedisConfig");
            services.Configure<RedisDbSettings>(redisConfiguration);

            services.AddSingleton<RedisContext>(sp =>
            {
                var redisSettings = sp.GetRequiredService<IOptions<RedisDbSettings>>().Value;

                var redis = new RedisContext(redisSettings.Host, redisSettings.Port);

                redis.Connect();
               
                return redis;
            });
        }
    }
}
