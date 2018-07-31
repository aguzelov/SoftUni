using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int? Age { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [InverseProperty("Buyer")]
        public ICollection<Product> Bought { get; set; } = new List<Product>();

        [InverseProperty("Seller")]
        public ICollection<Product> Sold { get; set; } = new List<Product>();
    }
}