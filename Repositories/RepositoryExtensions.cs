using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;
using MongoDB.Driver;

namespace Weblog.Repositories
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMongoDatabase>(provider =>
            {
                var server = new MongoClient();
                return server.GetDatabase("weblog");
            });

            services.AddScoped<IPostRepository>(provider =>
                new PostRepository(provider.GetRequiredService<IMongoDatabase>()));
        }
    }
}
