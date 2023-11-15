using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ALTC_WebSite.Models
{
    public class StaticData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string? aboutus { get; set; }
        public string? lang { get; set; }




    }
}
