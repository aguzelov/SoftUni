using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor.Models.Import
{
    [XmlType("comment")]
    public class CommentImportDto
    {
        [Required]
        [MaxLength(250)]
        [MinLength(1)]
        [XmlElement("content")]
        public string Content { get; set; }

        [Required]
        [MinLength(1)]
        [XmlElement("user")]
        public string User { get; set; }

        [Required]
        [XmlElement("post")]
        public PostIdImportDto Post { get; set; }
    }
}