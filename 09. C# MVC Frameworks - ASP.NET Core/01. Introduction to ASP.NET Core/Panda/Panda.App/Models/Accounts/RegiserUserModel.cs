using System.ComponentModel.DataAnnotations;

namespace Panda.App.Models
{
    public class RegiserUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }
    }
}