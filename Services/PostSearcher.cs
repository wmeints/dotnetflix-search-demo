using System;
using System.Threading.Tasks;
using Weblog.Models;
using Nest;

namespace Weblog.Services
{
	public class PostSearcher: IPostSearcher
	{
		private ElasticClient _client;		
		
		public PostSearcher()
		{
			var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);

            _client = new ElasticClient(settings);
		}
		
		public async Task<PagedResult<IndexedPost>> FindPostsAsync(string query, int pageIndex)
		{
			// Important: For easy search, stick to the query_string operator.
			// This will automatically convert your query string into terms and search for them.
			// Doing this manually is possible, but a more difficult to do. 
			var results = await _client.SearchAsync<IndexedPost>(searchRequest => searchRequest
				.Index("weblog")
				.Type("post")
				.From(pageIndex * 30)
				.Take(30)
				.Query(querySpec => querySpec.QueryString(
					queryString => queryString.DefaultField(post => post.Body).Query(query))));
			
			return new PagedResult<IndexedPost> {
				Items = results.Documents,
				PageSize = 30,
				PageIndex = pageIndex,
				Total = results.Total
			};
		}	
	}	
}