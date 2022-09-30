using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolves
{
    public static class BusinessModule
    {
        public static void Load(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
        }
    }
}
