using System.Xml.Serialization;

namespace ProductShop.DataProcessor.Models.Import
{
    [XmlType("product")]
    public class ProductImportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}