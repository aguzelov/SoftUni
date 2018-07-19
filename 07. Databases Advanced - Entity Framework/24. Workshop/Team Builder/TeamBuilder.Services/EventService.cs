using AutoMapper.QueryableExtensions;
using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.Services
{
    public class EventService : IEventService
    {
        private readonly TeamBuilderContext context;

        public EventService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void AddEvent(Event @event)
        {
            this.context.Events.Add(@event);

            this.context.SaveChanges();
        }

        public Event GetEvent(string eventName)
        {
            Event @event = this.context.Events
                .Where(e => e.Name == eventName)
                .OrderByDescending(e => e.StartDate)
                .First();

            return @event;
        }

        public TModel[] GetAllEvents<TModel>(string eventName)
        {
            TModel[] events = this.context.Events
                .Where(e => e.Name == eventName)
                .ProjectTo<TModel>()
                .ToArray();

            return events;
        }

        public bool IsEventExisting(string eventName)
        {
            return this.context.Events.Any(e => e.Name == eventName);
        }
    }
}