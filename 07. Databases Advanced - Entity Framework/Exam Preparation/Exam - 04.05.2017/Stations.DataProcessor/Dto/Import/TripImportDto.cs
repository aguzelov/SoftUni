using Stations.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stations.DataProcessor.Dto.Import
{
    public class TripImportDto
    {
        [Required]
        [MaxLength(10)]
        public string Train { get; set; }

        [Required]
        public string OriginStation { get; set; }

        [Required]
        public string DestinationStation { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Required]
        public string ArrivalTime { get; set; }

        [DefaultValue(TripStatus.OnTime)]
        public TripStatus Status { get; set; } = TripStatus.OnTime;

        public string TimeDifference { get; set; }
    }
}