using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Users
{
    public class RegisterUserViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "Username should be at least 3 symbols long.")]
        [Display(Name = "Username")]
        [RegularExpression("^[0-9a-zA-Z-_.*~]+$", ErrorMessage = "Username may only contain alphanumeric characters, dashes, underscores, dots, asterisks and tildes.")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password should be at least 5 symbols long.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "UCN")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Unique Citizen Number(UCN) should consist of exactly 10 numbers")]
        public string UniqueCitizenNumber { get; set; }
    }
}