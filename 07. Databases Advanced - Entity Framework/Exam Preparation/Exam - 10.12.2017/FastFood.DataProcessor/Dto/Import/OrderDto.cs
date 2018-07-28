using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor
{
    [XmlType("Order")]
    public class OrderDto
    {
        [Required]
        public string Customer { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Employee { get; set; }

        [Required]
        public string DateTime { get; set; }

        [Required]
        public string Type { get; set; }

        public OrderItemDto[] Items { get; set; }
    }
}