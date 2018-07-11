using System;

namespace BusTickets.Models
{
    public class ArrivedTrip
    {
        public int ArrivedTripId { get; set; }

        public DateTime ArriveTime { get; set; }

        public int Passengers { get; set; }

        public int? OriginBusStationId { get; set; }
        public BusStation OriginBusStation { get; set; }

        public int? DestinationBusStationId { get; set; }
        public BusStation DestinationBusStation { get; set; }
    }
}