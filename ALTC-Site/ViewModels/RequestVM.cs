using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ALTC_Website.ViewModels
{
    public class RequestVM
    {
        // public int id { get; set; }

        [RegularExpression(@"^[A-Za-z]+( [A-Za-z]+)+$", ErrorMessage = "The full name must contain at least two parts with only Arabic and English letters")]
        public string Name { get; set; }
        [RegularExpression(@"^01(0|1|2|5)\d{8}$", ErrorMessage = "Phone Must be 11 Numbers Begins with (010,011,012,015)")]
        public string Phone { get; set; }
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        public string? Details { get; set; }
        // [FileExtensions(Extensions = "pdf,rar,", ErrorMessage = "Only JPG, JPEG, PNG, and PDF files are allowed.")]
      //  [Remote("ValidFileExtension","Request",ErrorMessage ="Invalid file extension")]
        public IFormFile File { get; set; }

    }
}
