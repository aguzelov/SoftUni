using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShoppingList.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        [MinLength(1)]
        public string Status { get; set; }
    }
}