using System.Threading.Tasks;
using Weblog.Models;

namespace Weblog.Services
{
    public interface IPostIndexer
    {
        Task IndexAsync(Post post);
    }
}
