using Newtonsoft.Json;
using Stations.Models;
using System.ComponentModel.DataAnnotations;

namespace Stations.DataProcessor.Dto.Import
{
    public class TrainImportDto
    {
        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        public TrainType? Type { get; set; } = TrainType.HighSpeed;

        public TrainSeatImportDto[] Seats { get; set; } = new TrainSeatImportDto[0];
    }
}