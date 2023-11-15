using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ALTC_WebSite.Models
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Language { get; set; }

        public string Name { get; set; }
        public string Position { get; set; }
        public string? Phone { get; set; }
        public string? Linkedin { get; set; }
        public string? Facebook {  get; set; }
        public string?Twitter { get; set; }
        public string PhotoName { get; set; }

    }
}
