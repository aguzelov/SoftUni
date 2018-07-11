using BusTickets.Data;
using BusTickets.Models;
using BusTickets.Services.Contracts;
using System.Linq;

namespace BusTickets.Services
{
    public class TicketService : ITicketService
    {
        private readonly BusTicketsContext context;

        public TicketService(BusTicketsContext context)
        {
            this.context = context;
        }

        public void AddTicket(Customer customer, Trip trip, decimal price, int seat)
        {
            Ticket ticket = new Ticket
            {
                Customer = customer,
                Trip = trip,
                Price = price,
                Seat = seat
            };

            context.Tickets.Add(ticket);

            context.SaveChanges();
        }

        public Ticket GetTicketById(int id)
        {
            Ticket ticket = context.Tickets.FirstOrDefault(t => t.TicketId == id);

            return ticket;
        }

        public Ticket[] GetTicketByTripId(int id)
        {
            Ticket[] tickets = context.Tickets
                .Where(t => t.TripId == id)
                .ToArray();

            return tickets;
        }
    }
}