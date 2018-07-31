using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        [ForeignKey("Car_Id")]
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

        public virtual ICollection<PartCar> PartCars { get; set; } = new List<PartCar>();
    }
}