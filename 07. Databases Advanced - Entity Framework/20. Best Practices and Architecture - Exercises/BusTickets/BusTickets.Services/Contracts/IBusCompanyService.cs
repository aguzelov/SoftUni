using BusTickets.Models;

namespace BusTickets.Services.Contracts
{
    public interface IBusCompanyService
    {
        BusCompany GetBusCompanyById(int id);

        BusCompany GetBusCompanyByName(string name);
    }
}