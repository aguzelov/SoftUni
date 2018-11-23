using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eventures.Services
{
    public class EventsService : IEventsService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EventsService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ICollection<T> All<T>()
        {
            var events = this.context.Events
                .Select(e => this.mapper.Map<T>(e))
                .ToList();

            return events;
        }

        public bool Create(string name, string place, DateTime start, DateTime end, int totalTickets, decimal pricePerTicket)
        {
            if (name == null ||
                place == null ||
                start == null ||
                end == null ||
                totalTickets < 0 ||
                pricePerTicket < 0)
            {
                return false;
            }

            var @event = new Event
            {
                Name = name,
                Place = place,
                Start = start,
                End = end,
                TotalTickets = totalTickets,
                PricePerTicket = pricePerTicket
            };

            this.context.Events.Add(@event);
            this.context.SaveChanges();

            return true;
        }

        public Event GetById(string id)
        {
            var @event = this.context.Events.Find(id);

            return @event;
        }
    }
}