using Eventures.Models;
using System;
using System.Linq;

namespace Eventures.Services.Contracts
{
    public interface IEventsService
    {
        IQueryable<T> All<T>();

        bool Create(string name, string place, DateTime start, DateTime end, int totalTickets, decimal pricePerTicket);

        Event GetById(string id);
    }
}