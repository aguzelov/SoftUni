using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("Supplier")]
        public int Supplier_Id { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<PartCar> PartCars { get; set; } = new List<PartCar>();
    }
}