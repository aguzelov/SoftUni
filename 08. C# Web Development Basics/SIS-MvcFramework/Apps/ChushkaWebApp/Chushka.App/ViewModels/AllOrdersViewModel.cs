using System.Collections.Generic;

namespace Chushka.App.ViewModels
{
    public class AllOrdersViewModel
    {
        public ICollection<OrderViewModel> Orders { get; set; }
    }
}