using System;
using System.Threading.Tasks;
using Weblog.Models;

namespace Weblog.Services
{
	public interface IPostSearcher
	{
		Task<PagedResult<IndexedPost>> FindPostsAsync(string query, int pageIndex);		
	}
}