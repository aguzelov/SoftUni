using System.Xml.Serialization;

namespace Instagraph.DataProcessor.Models.Export
{
    [XmlType("user")]
    public class CommentsPostExportDto
    {
        [XmlElement("Username")]
        public string Username { get; set; }

        [XmlElement("MostComments")]
        public int MostComments { get; set; }
    }
}