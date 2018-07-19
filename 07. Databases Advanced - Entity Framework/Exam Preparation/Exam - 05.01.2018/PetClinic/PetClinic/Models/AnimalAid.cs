﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
    public class AnimalAid
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public ICollection<ProcedureAnimalAid> AnimalAidProcedures { get; set; } = new List<ProcedureAnimalAid>();
    }
}