using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Orders
{
    public class DisplayOrderViewModel
    {
        [Required]
        [Display(Name = "Event")]
        [DataType(DataType.Text)]
        public string EventName { get; set; }

        [Required]
        [Display(Name = "Customer")]
        [DataType(DataType.Text)]
        public string Customer { get; set; }

        [Required]
        [Display(Name = "Ordered On")]
        [DataType(DataType.DateTime)]
        public DateTime OrderedOn { get; set; }
    }
}