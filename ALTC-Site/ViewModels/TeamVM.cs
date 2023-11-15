using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ALTC_Site.ViewModels
{
    public class TeamVM
    {
         public string? Id { get; set; }
        [Remote("ValidLanguage", "Team", ErrorMessage = "The English letters")]

        public string Language { get; set; }

        [Remote("ValidTeamName", "Team", ErrorMessage = "The full name must contain at least two parts with only Arabic and English letters",AdditionalFields = "Language")]
        public string Name { get; set; }
        [RegularExpression(@"^01(0|1|2|5)\d{8}$", ErrorMessage = "Phone Must be 11 Numbers Begins with (010,011,012,015)")]
        public string? Phone { get; set; }

        public string Position { get; set; }

        // [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]

        public string? Linkedin { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        //[Remote("ValidPhotoExtension", "Team", ErrorMessage = "Only jpg,png are allowed")]
        public IFormFile? Photo { get; set; }

        public string? PhotoUrl { get; set;}

    }
}