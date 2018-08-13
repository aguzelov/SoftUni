using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ExportDto
{
    public class OfficersExportDto
    {
        public string OfficerName { get; set; }

        public string Department { get; set; }

        [JsonIgnore]
        public decimal Salary { get; set; }
    }
}