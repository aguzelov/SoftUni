using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Events
{
    public class CreateEventViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Place")]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End")]
        public DateTime End { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "TotalTickets")]
        public int TotalTickets { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "PricePerTicket")]
        public decimal PricePerTicket { get; set; }
    }
}