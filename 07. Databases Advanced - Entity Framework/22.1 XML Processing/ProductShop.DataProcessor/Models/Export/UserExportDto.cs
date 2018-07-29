using System.Xml.Serialization;

namespace ProductShop.DataProcessor.Models.Export
{
    [XmlType("users")]
    public class UserExportDto
    {
        [XmlAttribute("count")]
        public long Count { get; set; }

        [XmlElement("user")]
        public UserAndProductsDto[] Users { get; set; }
    }
}