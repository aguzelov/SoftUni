using System;

namespace Eventures.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public string EventId { get; set; }
        public virtual Event Event { get; set; }

        public string CustomerId { get; set; }
        public virtual User Customer { get; set; }

        public int TicketsCount { get; set; }
    }
}

/*
•	Ordered On – a DateTime object.
•	Event – an Event object.
•	Customer – a User object.
•	Tickets Count – an integer.

*/