using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Export
{
    [XmlType("car")]
    public class CarsFromMakeFerrariExportDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long Distance { get; set; }
    }
}