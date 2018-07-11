using BusTickets.Models;
using BusTickets.Services.Contracts;
using System;

namespace BusTickets.Client.Core.Commands
{
    public class ChangeTripStatusCommand : ICommand
    {
        private readonly ITripService tripService;
        private readonly IBusStationService busStationService;
        private readonly IArrivedTripService arrivedTripService;
        private readonly ITicketService ticketService;

        public ChangeTripStatusCommand(ITripService tripService, IBusStationService busStationService, IArrivedTripService arrivedTripService, ITicketService ticketService)
        {
            this.tripService = tripService;
            this.busStationService = busStationService;
            this.arrivedTripService = arrivedTripService;
            this.ticketService = ticketService;
        }

        public string Execute(string[] data)
        {
            int tripId = int.Parse(data[0]);
            Status newStatus = (Status)Enum.Parse(typeof(Status), data[1]);

            Trip trip = tripService.GetTripById(tripId);
            string oldStatus = trip.Status.ToString();
            trip.Status = newStatus;

            int originId = trip.OriginBusStationId ?? default(int);
            BusStation origin = busStationService.GetStationById(originId);

            int destinationId = trip.DestinationBusStationId ?? default(int);
            BusStation destination = busStationService.GetStationById(destinationId);

            DateTime dateTime = trip.DepartureTime;

            if (newStatus == Status.Arrived)
            {
                int passengers = this.ticketService.GetTicketByTripId(trip.TripId).Length;

                this.arrivedTripService.AddArrivalTrip(dateTime, origin, destination, passengers);

                return $"Trip from {origin.Town.Name} to {destination.Town.Name} on {dateTime.ToString("dd-MM-yyyy")}{Environment.NewLine}" +
                    $"Status changed from {oldStatus} to {newStatus}{Environment.NewLine}" +
                    $"On {dateTime.ToString("dd-MM-yyyy")} - {passengers} passengers arrived at {destination.Town.Name} from {origin.Town.Name}";
            }
            else
            {
                return $"Trip from {origin.Town.Name} to {destination.Town.Name} on {dateTime.ToString("dd-MM-yyyy")}{Environment.NewLine} Status changed from {oldStatus} to {newStatus}";
            }
        }
    }
}