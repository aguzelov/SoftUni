using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Users
{
    public class LoginUserViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "Username should be at least 3 symbols long.")]
        [Display(Name = "Username")]
        [RegularExpression("^[0-9a-zA-Z-_.*~]+$", ErrorMessage = "Username may only contain alphanumeric characters, dashes, underscores, dots, asterisks and tildes.")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password should be at least 5 symbols long.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}