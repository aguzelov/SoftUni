using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Import
{
    [XmlType("customer")]
    public class CustomerImportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("birth-date")]
        public string BirthDate { get; set; }

        [XmlElement("is-young-driver")]
        public bool IsYoungDriver { get; set; }
    }
}