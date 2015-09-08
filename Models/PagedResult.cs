using System.Collections.Generic;

namespace Weblog.Models
{
    public class PagedResult<TEntity>
    {
        public IEnumerable<TEntity> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Total { get; set; }
    }
}
