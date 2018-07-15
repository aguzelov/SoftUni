using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MinLength(3), MaxLength(15)]
        public string Name { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
    }
}