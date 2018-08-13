using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import
{
    [XmlType("Ticket")]
    public class TicketImportDto
    {
        [Required]
        [Range(0, double.MaxValue)]
        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{1,6}$")]
        [XmlAttribute("seat")]
        public string SeatingPlace { get; set; }

        [Required]
        [XmlElement("Trip")]
        public TicketTripImportDto Trip { get; set; }

        [XmlElement("Card")]
        public TicketCardImportDto Card { get; set; }
    }
}