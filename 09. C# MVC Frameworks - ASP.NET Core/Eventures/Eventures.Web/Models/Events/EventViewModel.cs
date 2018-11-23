using Eventures.Web.Models.Orders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Events
{
    public class EventViewModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Event name should be at least 10 symbols long.")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End")]
        public DateTime End { get; set; }

        public CreateOrderViewModel Order { get; set; }
    }
}