using FastFood.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FastFood.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [Required]
        [NotMapped]
        public decimal TotalPrice => this.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity);

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}