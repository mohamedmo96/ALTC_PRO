using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
namespace ALTC_Site.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Remote("IsUnique", "Account",ErrorMessage ="The email must be unique")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        public string Name {  get; set; }

        public string Role { get; set; } = "Admin";
    }
}
