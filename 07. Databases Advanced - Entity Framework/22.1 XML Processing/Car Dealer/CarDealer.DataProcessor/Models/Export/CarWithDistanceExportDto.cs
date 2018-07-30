using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Export
{
    [XmlType("car")]
    public class CarWithDistanceExportDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long Distance { get; set; }
    }
}