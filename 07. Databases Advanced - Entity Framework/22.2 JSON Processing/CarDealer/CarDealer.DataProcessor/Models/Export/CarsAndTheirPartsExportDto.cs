using Newtonsoft.Json;

namespace CarDealer.DataProcessor.Models.Export
{
    public class CarsAndTheirPartsExportDto
    {
        [JsonProperty("car")]
        public CarWithDistanceExportDto Car { get; set; }

        [JsonProperty("parts")]
        public PartsForCarExportDto[] Parts { get; set; }
    }
}