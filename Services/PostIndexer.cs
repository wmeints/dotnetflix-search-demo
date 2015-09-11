using System;
using System.Threading.Tasks;
using Weblog.Models;
using Nest;
using Polly;

namespace Weblog.Services
{
    public class PostIndexer: IPostIndexer
    {
        private static Policy CircuitBreaker = Policy
            .Handle<Exception>()
            .CircuitBreakerAsync(3, TimeSpan.FromSeconds(60));
        
        private ElasticClient _client;

        public PostIndexer()
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);

            _client = new ElasticClient(settings);
        }

        public async Task IndexAsync(Post post)
        {
            // Use a circuit breaker to make the indexer operation more resistent against problems.
            // When this operation fails three times, we stop for a minute before trying again.
            await CircuitBreaker.ExecuteAsync(async () => {
                // Indexes the content in ElasticSearch in the weblog index.
                // Uses the post type mapping defined earlier.
                return await _client.IndexAsync(post, (indexSelector) => indexSelector.Index("weblog").Type("post"));    
            });
        }
    }
}
