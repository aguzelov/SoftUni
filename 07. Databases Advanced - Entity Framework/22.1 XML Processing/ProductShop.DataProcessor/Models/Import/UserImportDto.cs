using System.Xml.Serialization;

namespace ProductShop.DataProcessor.Models.Import
{
    [XmlRoot("users")]
    [XmlType("user")]
    public class UserImportDto
    {
        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("lastName")]
        public string LastName { get; set; }

        [XmlIgnore]
        public int? Age { get; set; }

        [XmlAttribute("age")]
        public string AgeAsText
        {
            get { return (Age.HasValue) ? Age.ToString() : null; }
            set { Age = !string.IsNullOrEmpty(value) ? int.Parse(value) : default(int?); }
        }
    }
}