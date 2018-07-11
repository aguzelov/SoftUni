using BusTickets.Models;
using System;

namespace BusTickets.Initializer.Generators
{
    public class TicketGenerator
    {
        public static Ticket[] GenerateTicket(Customer[] customers, Trip[] trips)
        {
            Ticket[] tickets = new Ticket[trips.Length];

            Random random = new Random();

            for (int i = 0; i < tickets.Length; i++)
            {
                decimal price = random.Next(50, 400);
                int seat = random.Next(1, 30);

                tickets[i] = new Ticket
                {
                    Price = price,
                    Seat = seat,
                    Customer = customers[random.Next(0, customers.Length - 1)],
                    Trip = trips[i]
                };
            }

            return tickets;
        }
    }
}