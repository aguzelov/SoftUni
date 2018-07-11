using BusTickets.Models;

namespace BusTickets.Services.Contracts
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
    }
}