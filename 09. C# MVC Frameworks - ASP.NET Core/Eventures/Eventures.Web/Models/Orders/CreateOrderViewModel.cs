using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Orders
{
    public class CreateOrderViewModel
    {
        [Required]
        public string EventId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Tickets")]
        public int TicketsCount { get; set; }
    }
}