using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FastFood.DataProcessor
{
    [XmlType("Item")]
    public class OrderItemDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}