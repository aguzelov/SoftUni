using BusTickets.Data;
using BusTickets.Models;
using BusTickets.Services.Contracts;
using System;

namespace BusTickets.Services
{
    public class ArrivedTripService : IArrivedTripService
    {
        private readonly BusTicketsContext context;

        public ArrivedTripService(BusTicketsContext context)
        {
            this.context = context;
        }

        public void AddArrivalTrip(DateTime actualTime, BusStation originStation, BusStation destinationStation, int passengers)
        {
            ArrivedTrip arrivedTrip = new ArrivedTrip
            {
                ArriveTime = actualTime,
                OriginBusStation = originStation,
                DestinationBusStation = destinationStation,
                Passengers = passengers
            };

            context.ArrivedTrips.Add(arrivedTrip);

            context.SaveChanges();
        }
    }
}