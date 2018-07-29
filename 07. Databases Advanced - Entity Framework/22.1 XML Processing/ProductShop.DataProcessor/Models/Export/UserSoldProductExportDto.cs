using System.Xml.Serialization;

namespace ProductShop.DataProcessor.Models.Export
{
    [XmlType("user")]
    public class UserSoldProductExportDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlArray("sold-products")]
        public ProductExportDto[] SoldProducts { get; set; }
    }
}