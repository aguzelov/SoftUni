using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ByTheCake.Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new List<ProductsOrders>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public ICollection<ProductsOrders> Orders { get; set; }
    }
}