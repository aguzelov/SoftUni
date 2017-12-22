using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AnimeList.Models
{
    public class Anime
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }


        [Required]
        [StringLength(255, MinimumLength =1, ErrorMessage = "Non-empty text!")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Non-empty text!")]
        public string Description { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Non-empty text!")]
        public string Watched { get; set; }
    }
}