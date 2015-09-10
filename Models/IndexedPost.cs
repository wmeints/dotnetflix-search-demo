using System;
using System.Collections.Generic;

namespace Weblog.Models
{
	public class IndexedPost
	{
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Alias { get; set; }
        public DateTime DatePublished { get; set; }
        public List<string> Tags { get; set; }
        public AuthorInfo Author { get; set; }
	}
}