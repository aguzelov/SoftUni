using BusTickets.Models;
using BusTickets.Services.Contracts;
using System.Text;

namespace BusTickets.Client.Core.Commands
{
    public class PrintInfoCommand : ICommand
    {
        private readonly IBusStationService busStationService;
        private readonly ITripService tripService;

        public PrintInfoCommand(IBusStationService busStationService, ITripService tripService)
        {
            this.busStationService = busStationService;
            this.tripService = tripService;
        }

        public string Execute(string[] data)
        {
            int id = int.Parse(data[0]);

            BusStation station = busStationService.GetStationById(id);

            var sb = new StringBuilder();
            sb.AppendLine($"{station.Name}, {station.Town.Name}");
            sb.AppendLine("Arrivals:");
            foreach (var arrival in station.ArrivedTrips)
            {
                int tripId = arrival.TripId;
                Trip trip = tripService.GetTripById(tripId);

                sb.AppendLine($"From {trip.OriginBusStation.Name} | Arrive at: {trip.ArrivalTime.ToString("dd-MM-yyyy")} | Status: {trip.Status}");
            }

            sb.AppendLine("Departures:");
            foreach (var departed in station.DepartedTrips)
            {
                int tripId = departed.TripId;
                Trip trip = tripService.GetTripById(tripId);

                sb.AppendLine($"From {trip.DestinationBusStation.Name} | Depart at: {trip.DepartureTime.ToString("dd-MM-yyyy")} | Status: {trip.Status}");
            }

            return sb.ToString();
        }
    }
}