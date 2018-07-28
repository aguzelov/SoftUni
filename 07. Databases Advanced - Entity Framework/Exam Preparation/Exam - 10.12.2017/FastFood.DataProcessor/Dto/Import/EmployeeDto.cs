using System.ComponentModel.DataAnnotations;

namespace FastFood.DataProcessor
{
    public class EmployeeDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(15, 80)]
        public int Age { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Position { get; set; }
    }
}