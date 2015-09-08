using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Weblog.Models;

namespace Weblog.Repositories
{
    public interface IPostRepository
    {
        Task<Post> FindByAliasAsync(string alias);
        Task<Post> FindByIdAsync(ObjectId identifier);
        Task<PagedResult<Post>> FindAll(int pageIndex);
    }
}
