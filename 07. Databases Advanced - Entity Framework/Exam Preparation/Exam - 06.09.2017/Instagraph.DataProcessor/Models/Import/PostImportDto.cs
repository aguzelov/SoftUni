using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor.Models.Import
{
    [XmlType("post")]
    public class PostImportDto
    {
        [Required]
        [MinLength(1)]
        [XmlElement("caption")]
        public string Caption { get; set; }

        [Required]
        [MinLength(1)]
        [XmlElement("user")]
        public string User { get; set; }

        [Required]
        [MinLength(1)]
        [XmlElement("picture")]
        public string Picture { get; set; }
    }
}