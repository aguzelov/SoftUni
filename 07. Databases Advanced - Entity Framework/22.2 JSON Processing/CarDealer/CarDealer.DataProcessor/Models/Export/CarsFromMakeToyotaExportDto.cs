namespace CarDealer.DataProcessor.Models.Export
{
    public class CarsFromMakeToyotaExportDto
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }
    }
}