using CakesWebApp.ViewModels.Cakes;
using System.Collections.Generic;

namespace CakesWebApp.ViewModels.Orders
{
    public class GetByIdViewModel
    {
        public int Id { get; set; }

        public bool IsShoppingCart { get; set; }

        public IEnumerable<CakeViewModel> Products { get; set; }
    }
}