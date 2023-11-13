using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ALTC_WebSite.Models
{
    public class Login
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        
    }
}
