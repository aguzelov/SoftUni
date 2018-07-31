namespace CarDealer.DataProcessor.Models.Export
{
    public class CarWithDistanceExportDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }
    }
}