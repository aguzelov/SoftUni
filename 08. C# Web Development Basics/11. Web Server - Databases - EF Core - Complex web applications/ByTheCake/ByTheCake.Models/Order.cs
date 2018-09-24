using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ByTheCake.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new List<ProductsOrders>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<ProductsOrders> Products { get; set; }
    }
}