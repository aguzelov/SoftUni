using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("Buyer")]
        public int? BuyerId { get; set; }

        public virtual User Buyer { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }

        public virtual User Seller { get; set; }

        [ForeignKey("ProductId")]
        public virtual ICollection<CategoryProducts> CategoryProducts { get; set; } = new List<CategoryProducts>();
    }
}