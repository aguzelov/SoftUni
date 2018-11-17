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

        public EventsController(IEventsService eventsService, ILogger<EventsController> logger)
        {
            this.eventsService = eventsService;
            this.logger = logger;
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
        [HttpPost]
        public IActionResult Create(CreateEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var result = this.eventsService.Create(model.Name, model.Place, model.Start, model.End, model.TotalTickets, model.PricePerTicket);

            if (!result)
            {
                return this.View();
            }
            this.logger.LogInformation($"Event created: {model.Name}", model);

            return this.RedirectToAction(nameof(All));
        }
    }
}