using System.Xml.Serialization;

namespace ProductShop.DataProcessor.Models.Export
{
    [XmlType("sold-products ")]
    public class SoldProductsExportDto
    {
        [XmlAttribute("count")]
        public long Count { get; set; }

        [XmlElement("product")]
        public ProductByUserExportDto[] Products { get; set; }
    }
}