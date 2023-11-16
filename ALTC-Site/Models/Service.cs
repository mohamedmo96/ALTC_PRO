using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ALTC_WebSite.Models
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
        public string Details { get; set; }
    }
}
