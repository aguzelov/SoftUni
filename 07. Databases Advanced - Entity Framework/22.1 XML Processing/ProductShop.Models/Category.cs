using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ICollection<CategoryProducts> CategoryProducts { get; set; } = new List<CategoryProducts>();
    }
}