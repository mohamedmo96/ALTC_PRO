using System.ComponentModel.DataAnnotations;

namespace ALTC_Site.ViewModels
{
    public class LoginVM
    {

        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
