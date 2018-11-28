using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Users
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}