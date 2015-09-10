using Microsoft.Framework.DependencyInjection;

namespace Weblog.Services
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPostIndexer>(provider => new PostIndexer());
            services.AddScoped<IPostSearcher>(provider => new PostSearcher());
        }
    }
}
