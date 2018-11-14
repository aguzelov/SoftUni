using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chushka.Web.Models.Products
{
    public class CreateProductViewModel
    {
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Type { get; set; }

        public ICollection<string> Types { get; set; }
    }
}