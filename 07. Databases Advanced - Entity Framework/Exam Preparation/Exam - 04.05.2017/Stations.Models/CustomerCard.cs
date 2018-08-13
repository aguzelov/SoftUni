﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stations.Models
{
    public class CustomerCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        [DefaultValue(CardType.Normal)]
        public CardType Type { get; set; }

        public ICollection<Ticket> BoughtTickets { get; set; } = new List<Ticket>();
    }
}