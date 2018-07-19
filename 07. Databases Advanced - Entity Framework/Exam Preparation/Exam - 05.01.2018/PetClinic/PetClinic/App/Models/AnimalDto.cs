using System.ComponentModel.DataAnnotations;

namespace PetClinic.App.Models
{
    public class AnimalDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        [Required]
        [Range(1, 555)]
        public int Age { get; set; }

        public AnimalPassportDto Passport { get; set; }
    }
}