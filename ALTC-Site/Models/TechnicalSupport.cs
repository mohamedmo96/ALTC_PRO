using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace ALTC_WebSite.Models
{
    public class TechnicalSupport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^01\d{9}$", ErrorMessage = "Invalid phone number. The phone number must start with '01' and have a total length of 11 digits.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [StringLength(500, ErrorMessage = "Details must be less than 500 characters")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Services is required")]
        public string Services { get; set; }
    }


}
 
