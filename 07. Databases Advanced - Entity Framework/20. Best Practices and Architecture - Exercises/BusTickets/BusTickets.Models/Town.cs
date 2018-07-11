using System.Collections.Generic;

namespace BusTickets.Models
{
    public class Town
    {
        public int TownId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<BusStation> BusStations { get; set; } = new List<BusStation>();
    }
}