using AutoMapper.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Entities.DependencyResolvers
{
    public static class EntitiesModule
    {
        public static void Load(this IServiceCollection services)
        {
            services.AddAutoMapper(configAction =>
            {
                configAction.Internal().MethodMappingEnabled = false; //TODO(Bu satır 11.0.2 versiyonunda düzeltilmiş olacak, kaldırılabilir. Henüz sürüm yayınlanmadı.)
            }, typeof(EntitiesModule).Assembly);
        }
    }
}
