using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Export
{
    [XmlType("car")]
    public class CarsAndTheirPartsExportDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long Distance { get; set; }

        [XmlArray("parts")]
        public PartsForCarExportDto[] Parts { get; set; }
    }
}