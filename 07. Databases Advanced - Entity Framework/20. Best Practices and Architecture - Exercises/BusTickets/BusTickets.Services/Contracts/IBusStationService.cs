using BusTickets.Models;

namespace BusTickets.Services.Contracts
{
    public interface IBusStationService
    {
        BusStation GetStationById(int id);
    }
}