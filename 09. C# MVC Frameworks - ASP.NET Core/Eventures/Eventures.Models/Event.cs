using System;

namespace Eventures.Models
{
    public class Event
    {
        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TotalTickets { get; set; }

        public decimal PricePerTicket { get; set; }
    }
}