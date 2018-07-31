using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsImporter { get; set; }

        public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}