using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.Models.Orders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventures.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        private readonly UserManager<User> userManager;
        private readonly IEventsService eventsService;

        public OrdersController(IOrdersService ordersService, UserManager<User> userManager, IEventsService eventsService)
        {
            this.ordersService = ordersService;
            this.userManager = userManager;
            this.eventsService = eventsService;
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(actionName: "All", controllerName: "Events");
            }

            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            var @event = this.eventsService.GetById(model.EventId);

            if (@event.TotalTickets < model.TicketsCount)
            {
                return this.RedirectToAction(actionName: "All", controllerName: "Events");
            }

            var result = this.ordersService.Create(user, @event, model.TicketsCount);

            if (!result)
            {
                return this.RedirectToAction(actionName: "All", controllerName: "Events");
            }

            return this.RedirectToAction(actionName: "MyEvents", controllerName: "Events");
        }

        public IActionResult All()
        {
            var orders = this.ordersService.All<DisplayOrderViewModel>();

            return this.View(orders);
        }
    }
}