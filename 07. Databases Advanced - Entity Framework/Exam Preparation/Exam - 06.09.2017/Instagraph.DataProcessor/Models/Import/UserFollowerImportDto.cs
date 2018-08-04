using System.ComponentModel.DataAnnotations;

namespace Instagraph.DataProcessor.Models.Import
{
    public class UserFollowerImportDto
    {
        [Required]
        [MaxLength(30)]
        public string User { get; set; }

        [Required]
        [MaxLength(30)]
        public string Follower { get; set; }
    }
}