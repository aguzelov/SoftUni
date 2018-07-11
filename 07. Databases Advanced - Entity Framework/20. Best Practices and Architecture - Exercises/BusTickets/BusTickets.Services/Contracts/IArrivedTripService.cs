using BusTickets.Models;
using System;

namespace BusTickets.Services.Contracts
{
    public interface IArrivedTripService
    {
        void AddArrivalTrip(DateTime actualTime, BusStation originStation, BusStation destinationStation, int passengers);
    }
}