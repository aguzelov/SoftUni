using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Import
{
    [XmlType("part")]
    public class PartImportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("quantity")]
        public int Quantity { get; set; }
    }
}