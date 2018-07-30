using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Export
{
    [XmlType("suplier")]
    public class LocalSupplierExportDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int Count { get; set; }
    }
}