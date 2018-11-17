using Eventures.Web.Models.Events;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Eventures.Web.Filters
{
    public class EventsCreateLogActionFilter : ActionFilterAttribute
    {
        private readonly ILogger logger;
        private CreateEventViewModel model;

        public EventsCreateLogActionFilter(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<EventsCreateLogActionFilter>();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.model = context.ActionArguments.Values.OfType<CreateEventViewModel>().Single();

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (this.model != null)
            {
                var dateNow = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm");
                var adminName = context.HttpContext.User.Identity.Name;
                var eventName = this.model.Name;
                var eventStart = this.model.Start.ToString("dd/MM/yyyy HH:mm");
                var eventEnd = this.model.End.ToString("dd/MM/yyyy HH:mm");

                this.logger.LogInformation($"[{dateNow}] Administrator {adminName} create event {eventName} ({eventStart} / {eventEnd}).");
            }

            base.OnActionExecuted(context);
        }
    }
}