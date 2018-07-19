using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PetClinic.Models
{
    public class Procedure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }

        [Required]
        public int VetId { get; set; }

        public Vet Vet { get; set; }

        public decimal Cost => this.ProcedureAnimalAids
            .Select(paa => paa.AnimalAid.Price)
            .Sum();

        [Required]
        public DateTime DateTime { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; } = new List<ProcedureAnimalAid>();
    }
}