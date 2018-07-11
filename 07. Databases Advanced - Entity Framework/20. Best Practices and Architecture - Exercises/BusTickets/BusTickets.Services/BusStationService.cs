using BusTickets.Data;
using BusTickets.Models;
using BusTickets.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusTickets.Services
{
    public class BusStationService : IBusStationService
    {
        private readonly BusTicketsContext context;

        public BusStationService(BusTicketsContext context)
        {
            this.context = context;
        }

        public BusStation GetStationById(int id)
        {
            BusStation station = context.BusStations
                .Where(b => b.BusStationId == id)
                .Include(b => b.Town)
                .Include(bs => bs.ArrivedTrips)
                .Include(bs => bs.DepartedTrips)
                .FirstOrDefault();

            return station;
        }
    }
}