using System.ComponentModel.DataAnnotations;

namespace Instagraph.DataProcessor.Models.Import
{
    public class PictureImportDto
    {
        [Required]
        [MinLength(1)]
        public string Path { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Size { get; set; }
    }
}