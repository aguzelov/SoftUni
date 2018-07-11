using BusTickets.Data;
using BusTickets.Initializer.Generators;
using BusTickets.Models;
using System;

namespace BusTickets.Initializer
{
    public static class DbInitializer
    {
        public static void Seed(BusTicketsContext context)
        {
            Town[] towns = TownGenerator.GenerateTowns();
            context.Towns.AddRange(towns);

            BusCompany[] companies = BusCompanyGenerator.GenerateBusCompanies();
            context.BusCompanies.AddRange(companies);

            BusStation[] stations = BusStationGenerator.GenerateBusStations(towns);
            context.BusStations.AddRange(stations);

            Customer[] customers = CustomerGenerator.GenerateCustomers(towns);
            context.Customers.AddRange(customers);

            BankAccount[] accounts = BankAccountGenerator.GenerateBankAccounts(customers);
            context.BankAccounts.AddRange(accounts);

            //BusCompany[] companiesFromDb = context.BusCompanies.ToArray();
            Review[] reviews = ReviewGenerator.GenerateReviews(companies, customers);
            context.Reviews.AddRange(reviews);

            Trip[] trips = TripGenerator.GenerateTrips(stations, companies);
            context.Trips.AddRange(trips);

            Ticket[] tickets = TicketGenerator.GenerateTicket(customers, trips);
            context.Tickets.AddRange(tickets);

            context.SaveChanges();

            Console.WriteLine("Sample data inserted successfully.");
        }
    }
}