using BusTickets.Data;
using BusTickets.Models;
using BusTickets.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusTickets.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BusTicketsContext context;

        public CustomerService(BusTicketsContext context)
        {
            this.context = context;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = context.Customers
                .Include(c => c.BankAccount)
                .FirstOrDefault(c => c.CustomerId == id);

            return customer;
        }
    }
}