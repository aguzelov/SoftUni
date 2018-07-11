using BusTickets.Data;
using BusTickets.Models;
using BusTickets.Services.Contracts;
using System.Linq;

namespace BusTickets.Services
{
    public class BusCompanyService : IBusCompanyService
    {
        private readonly BusTicketsContext context;

        public BusCompanyService(BusTicketsContext context)
        {
            this.context = context;
        }

        public BusCompany GetBusCompanyById(int id)
        {
            BusCompany busCompany = context.BusCompanies.FirstOrDefault(bc => bc.BusCompanyId == id);

            return busCompany;
        }

        public BusCompany GetBusCompanyByName(string name)
        {
            BusCompany busCompany = context.BusCompanies.FirstOrDefault(bc => bc.Name == name);

            return busCompany;
        }
    }
}