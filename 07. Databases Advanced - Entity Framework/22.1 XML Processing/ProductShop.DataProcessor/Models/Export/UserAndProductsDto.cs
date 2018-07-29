using System.Xml.Serialization;

namespace ProductShop.DataProcessor.Models.Export
{
    [XmlType("user")]
    public class UserAndProductsDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlIgnore]
        public int? Age { get; set; }

        [XmlAttribute("age")]
        public string AgeAsText
        {
            get { return (Age.HasValue) ? Age.ToString() : null; }
            set { Age = !string.IsNullOrEmpty(value) ? int.Parse(value) : default(int?); }
        }

        [XmlElement("sold-products")]
        public SoldProductsExportDto SoldProducts { get; set; }
    }
}