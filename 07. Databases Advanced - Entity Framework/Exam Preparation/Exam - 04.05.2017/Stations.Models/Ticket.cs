using System.ComponentModel.DataAnnotations;

namespace Stations.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression("^([A-Za-z]{2})([0-9]{1,6})$")]
        public string SeatingPlace { get; set; }

        [Required]
        public int TripId { get; set; }

        public Trip Trip { get; set; }

        public int? CustomerCardId { get; set; }
        public CustomerCard CustomerCard { get; set; }
    }
}