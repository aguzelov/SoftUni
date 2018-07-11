using BusTickets.Models;

namespace BusTickets.Services.Contracts
{
    public interface ITicketService
    {
        Ticket GetTicketById(int id);

        Ticket[] GetTicketByTripId(int id);

        void AddTicket(Customer customer, Trip trip, decimal price, int seat);
    }
}