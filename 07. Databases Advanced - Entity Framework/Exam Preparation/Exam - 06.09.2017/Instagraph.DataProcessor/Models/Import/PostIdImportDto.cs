using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor.Models.Import
{
    [XmlType("post")]
    public class PostIdImportDto
    {
        [Required]
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}