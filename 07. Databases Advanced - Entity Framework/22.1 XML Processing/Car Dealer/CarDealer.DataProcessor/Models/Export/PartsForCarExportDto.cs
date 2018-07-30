using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Export
{
    [XmlType("part")]
    public class PartsForCarExportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}