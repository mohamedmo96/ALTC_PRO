using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ALTC_WebSite.Models
{
    public class Department
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string Name { get; set; }
        public string? Describtion { get; set; }
        public string FileName { get; set; }
        public string lang { get; set; }
    }
}
