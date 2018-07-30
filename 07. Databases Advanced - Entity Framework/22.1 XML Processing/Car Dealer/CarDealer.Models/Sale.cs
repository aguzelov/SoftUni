using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Discount { get; set; }

        public int Car_Id { get; set; }

        public virtual Car Car { get; set; }

        public int Customer_Id { get; set; }

        public virtual Customer Customer { get; set; }
    }
}