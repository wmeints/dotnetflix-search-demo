using System;
using System.Threading.Tasks;
using Weblog.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Weblog.Repositories
{
    public class PostRepository : IPostRepository
    {
        private IMongoDatabase _database;
        private IMongoCollection<Post> _collection;

        public PostRepository(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection <Post> ("posts");
        }

        public Task<Post> FindByAliasAsync(string alias)
        {
            return _collection
                .Find(Builders<Post>.Filter.Eq(post => post.Alias, alias))
                .FirstOrDefaultAsync();
        }

        public Task<Post> FindByIdAsync(ObjectId identifier)
        {
            return _collection
                .Find(Builders<Post>.Filter.Eq(post => post.Id, identifier))
                .FirstOrDefaultAsync();
        }

        public async Task<PagedResult<Post>> FindAll(int pageIndex) {
            var items = await _collection
                .Find(new BsonDocument())
                .Sort(Builders<Post>.Sort.Ascending(post => post.DatePublished))
                .Skip(pageIndex * 30)
                .Limit(30)
                .ToListAsync();

            var total = await _collection
                .Find(new BsonDocument())
                .CountAsync();

            return new PagedResult<Post>
            {
                Total = total,
                Items = items,
                PageSize = 30,
                PageIndex = pageIndex,
            };
        }
    }
}
