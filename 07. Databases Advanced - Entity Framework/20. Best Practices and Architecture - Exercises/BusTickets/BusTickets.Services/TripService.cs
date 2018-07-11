using BusTickets.Data;
using BusTickets.Models;
using BusTickets.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusTickets.Services
{
    public class TripService : ITripService
    {
        private readonly BusTicketsContext context;

        public TripService(BusTicketsContext context)
        {
            this.context = context;
        }

        public Trip GetTripById(int id)
        {
            Trip trip = context.Trips
                .Include(t => t.BusCompany)
                .Include(t => t.OriginBusStation)
                .Include(t => t.DestinationBusStation)
                .FirstOrDefault(t => t.TripId == id);

            return trip;
        }
    }
}