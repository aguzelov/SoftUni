using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eventures.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OrdersService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool Create(User user, Event @event, int ticketsCount)
        {
            if (user == null ||
                @event == null ||
                ticketsCount <= 0)
            {
                return false;
            }

            var order = new Order
            {
                Customer = user,
                Event = @event,
                TicketsCount = ticketsCount,
                OrderedOn = DateTime.UtcNow
            };

            @event.TotalTickets -= ticketsCount;

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return true;
        }

        public ICollection<T> All<T>()
        {
            var orders = this.context.Orders
                .ToList();

            var model = orders
                .Select(o => this.mapper.Map<T>(o))
                .ToList();

            return model;
        }

        public ICollection<T> AllByUser<T>(string username)
        {
            var orders = this.context.Orders
                .Where(o => o.Customer.UserName == username)
                .ToList();

            var models = orders.Select(o => this.mapper.Map<T>(o)).ToList();

            return models;
        }
    }
}