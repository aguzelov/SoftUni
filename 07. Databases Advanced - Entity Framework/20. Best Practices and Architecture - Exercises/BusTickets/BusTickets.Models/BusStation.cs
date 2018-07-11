using System.Collections.Generic;

namespace BusTickets.Models
{
    public class BusStation
    {
        public int BusStationId { get; set; }

        public string Name { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Trip> DepartedTrips { get; set; } = new List<Trip>();

        public ICollection<Trip> ArrivedTrips { get; set; } = new List<Trip>();

        public ICollection<ArrivedTrip> OriginTrips { get; set; } = new List<ArrivedTrip>();

        public ICollection<ArrivedTrip> DestinationTrips { get; set; } = new List<ArrivedTrip>();
    }
}