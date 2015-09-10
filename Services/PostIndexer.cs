using System;
using System.Threading.Tasks;
using Weblog.Models;
using Nest;

namespace Weblog.Services
{
    public class PostIndexer: IPostIndexer
    {
        private ElasticClient _client;

        public PostIndexer()
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);

            _client = new ElasticClient(settings);
        }

        public async Task IndexAsync(Post post)
        {
            // Indexes the content in ElasticSearch in the weblog index.
            // Uses the post type mapping defined earlier.
            await _client.IndexAsync(post,
                (indexSelector) => indexSelector.Index("weblog").Type("post"));
        }
    }
}
