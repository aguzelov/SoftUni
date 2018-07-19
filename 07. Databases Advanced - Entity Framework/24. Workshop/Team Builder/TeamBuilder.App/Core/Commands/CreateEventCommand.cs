using System;
using System.Globalization;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class CreateEventCommand : ICommand
    {
        private readonly IEventService eventService;

        public CreateEventCommand(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public string Execute(string[] commandArg)
        {
            Check.CheckLength(6, commandArg);

            string eventName = commandArg[0];
            string description = commandArg[1];
            string startDateStr = commandArg[2] + " " + commandArg[3];
            string endDateStr = commandArg[4] + " " + commandArg[5];

            ValidateDates(startDateStr, endDateStr, out DateTime startDate, out DateTime endDate);

            User creator = Session.Session.GetCurrentUser();
            Event @event = new Event
            {
                Name = eventName,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                Creator = creator
            };

            this.eventService.AddEvent(@event);

            return $"Event {@event.Name} was created successfully!";
        }

        private void ValidateDates(string startDateStr, string endDateStr, out DateTime startDate, out DateTime endDate)
        {
            startDate = default(DateTime);
            endDate = default(DateTime);

            try
            {
                startDate = DateTime.ParseExact(startDateStr, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                endDate = DateTime.ParseExact(endDateStr, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                string errMsg = Constants.ErrorMessages.InvalidDateFormat;
                throw new ArgumentException(errMsg);
            }

            if (startDate > endDate)
            {
                string errMsg = Constants.ErrorMessages.StartDateBeforeEndDate;
                throw new ArgumentException(errMsg);
            }
        }
    }
}