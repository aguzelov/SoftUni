using Stations.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import
{
    [XmlType("Card")]
    public class CustomerCardImportDto
    {
        [Required]
        [MaxLength(128)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Range(0, 120)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [DefaultValue(CardType.Normal)]
        [XmlElement("CardType")]
        public CardType Type { get; set; }
    }
}