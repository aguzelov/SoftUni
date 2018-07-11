using BusTickets.Models;

namespace BusTickets.Services.Contracts
{
    public interface ITripService
    {
        Trip GetTripById(int id);
    }
}