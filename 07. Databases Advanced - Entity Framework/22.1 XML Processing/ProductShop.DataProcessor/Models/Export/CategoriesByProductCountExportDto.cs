using System.Xml.Serialization;

namespace ProductShop.DataProcessor.Models.Export
{
    [XmlType("category")]
    public class CategoriesByProductCountExportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("products-count")]
        public long ProductCount { get; set; }

        [XmlElement("average-price")]
        public decimal AveragePrice { get; set; }

        [XmlElement("total-revenue")]
        public decimal TotalRevenue { get; set; }
    }
}