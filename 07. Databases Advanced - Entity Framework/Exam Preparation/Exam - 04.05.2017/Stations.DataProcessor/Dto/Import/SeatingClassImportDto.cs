using System.ComponentModel.DataAnnotations;

namespace Stations.DataProcessor.Dto.Import
{
    public class SeatingClassImportDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        public string Abbreviation { get; set; }
    }
}