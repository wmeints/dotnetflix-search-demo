using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Weblog.Models
{
    public class Post
    {
        [BsonElement("id")]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("body")]
        public string Body { get; set; }

        [BsonElement("alias")]
        public string Alias { get; set; }

        [BsonElement("datePublished")]
        public DateTime DatePublished { get; set; }

        [BsonElement("tags")]
        public List<string> Tags { get; set; }

        [BsonElement("author")]
        public AuthorInfo Author { get; set; }
    }
}
