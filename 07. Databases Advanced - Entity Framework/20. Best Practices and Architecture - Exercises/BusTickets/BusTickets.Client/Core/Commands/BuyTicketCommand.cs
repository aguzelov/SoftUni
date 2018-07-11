using BusTickets.Models;
using BusTickets.Services.Contracts;
using System;

namespace BusTickets.Client.Core.Commands
{
    public class BuyTicketCommand : ICommand
    {
        private readonly ICustomerService customerService;
        private readonly ITripService tripService;
        private readonly ITicketService ticketService;

        public BuyTicketCommand(ICustomerService customerService, ITripService tripService, ITicketService ticketService)
        {
            this.customerService = customerService;
            this.tripService = tripService;
            this.ticketService = ticketService;
        }

        public string Execute(string[] data)
        {
            int customerId = int.Parse(data[0]);
            int tripId = int.Parse(data[1]);
            decimal price = decimal.Parse(data[2]);
            int seat = int.Parse(data[3]);

            if (price < 0)
            {
                throw new ArgumentException("Invalid price");
            }

            Customer customer = customerService.GetCustomerById(customerId);

            if (customer.BankAccount.Balance < price)
            {
                throw new InvalidOperationException("Not enough monney for this purchise!");
            }
            else
            {
                customer.BankAccount.Balance -= price;
            }

            Trip trip = tripService.GetTripById(tripId);

            ticketService.AddTicket(customer, trip, price, seat);

            return $"Customer {customer.FirstName} {customer.LastName} bought ticket for trip {trip.TripId} for {price} on seat {seat}";
        }
    }
}