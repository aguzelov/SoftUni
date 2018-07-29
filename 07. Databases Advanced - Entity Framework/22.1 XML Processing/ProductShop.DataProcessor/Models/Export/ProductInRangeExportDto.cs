using System.Xml.Serialization;

namespace ProductShop.DataProcessor.Models.Export
{
    [XmlType("product")]
    public class ProductInRangeExportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("buyer")]
        public string BuyerFullName { get; set; }
    }
}