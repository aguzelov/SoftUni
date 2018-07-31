using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [DefaultValue(false)]
        public bool IsYoungDriver { get; set; }

        [ForeignKey("Customer_Id")]
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}