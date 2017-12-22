using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IMDB.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Genre { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Director { get; set; }

        [Range(0, 2100, ErrorMessage = "Please enter valid year 0 - 2100!")]
        public int Year { get; set; }
    }
}