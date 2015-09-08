using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Weblog.Models
{
    public class AuthorInfo
    {
        [BsonElement("fullName")]
        public string FullName { get; set; }

        [BsonElement("emailAddress")]
        public string EmailAddress { get; set; }
    }
}
