using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class MessageExportDto
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}