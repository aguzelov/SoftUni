using Eventures.Services.Contracts;
using Eventures.Web.Filters;
using Eventures.Web.Models.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventures.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;
        private readonly ILogger<EventsController> logger;
        private readonly IOrdersService ordersService;

        public EventsController(
            IEventsService eventsService,
            ILogger<EventsController> logger,
            IOrdersService ordersService)
        {
            this.eventsService = eventsService;
            this.logger = logger;
            this.ordersService = ordersService;
        }

        [Authorize]
        public IActionResult All()
        {
            var events = this.eventsService.All<EventViewModel>();

            return this.View(events);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create() => this.View();

        [ServiceFilter(typeof(EventsCreateLogActionFilter))]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(CreateEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.eventsService.Create(model.Name, model.Place, model.Start, model.End, model.TotalTickets, model.PricePerTicket);

            if (!result)
            {
                return this.View(model);
            }
            this.logger.LogInformation($"Event created: {model.Name}", model);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult MyEvents()
        {
            var username = this.User.Identity.Name;
            var orders = this.ordersService.AllByUser<EventWithTicketsCountViewModel>(username);

            return this.View(orders);
        }
    }
}