using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import
{
    [XmlType("Card")]
    public class TicketCardImportDto
    {
        [Required]
        [MaxLength(128)]
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}