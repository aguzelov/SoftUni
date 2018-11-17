using System;
using System.Collections.Generic;

namespace Eventures.Services.Contracts
{
    public interface IEventsService
    {
        ICollection<T> All<T>();

        bool Create(string name, string place, DateTime start, DateTime end, int totalTickets, decimal pricePerTicket);
    }
}