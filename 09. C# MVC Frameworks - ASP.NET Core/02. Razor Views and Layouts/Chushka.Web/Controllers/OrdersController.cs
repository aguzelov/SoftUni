using Chushka.Services.Contracts;
using Chushka.Web.Models.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chushka.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            var orders = this.ordersService.All<DetailsOrderViewModel>();

            return this.View(orders);
        }

        [Authorize]
        public IActionResult Order(string id)
        {
            var username = this.User.Identity.Name;

            var isOrdered = this.ordersService.Order(id, username);

            if (!isOrdered)
                return this.Redirect("/");

            if (this.User.IsInRole("Admin"))
            {
                return this.RedirectToAction(nameof(All));
            }

            return this.Redirect("/");
        }
    }
}