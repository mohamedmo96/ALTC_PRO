using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ALTC_WebSite.Models
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string PhotoName { get; set; }
    }
}
