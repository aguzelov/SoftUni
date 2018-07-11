using BusTickets.Models;
using BusTickets.Services.Contracts;
using System;

namespace BusTickets.Client.Core.Commands
{
    public class PublishReviewCommand : ICommand
    {
        private readonly ICustomerService customerService;

        private readonly IBusCompanyService busCompanyService;

        private readonly IReviewService reviewService;

        public PublishReviewCommand(ICustomerService customerService, IBusCompanyService busCompanyService, IReviewService reviewService)
        {
            this.customerService = customerService;
            this.busCompanyService = busCompanyService;
            this.reviewService = reviewService;
        }

        public string Execute(string[] data)
        {
            int customerId = int.Parse(data[0]);
            float grade = float.Parse(data[1]);
            string busCompanyName = data[2];
            string content = data[3];

            Customer customer = customerService.GetCustomerById(customerId);
            BusCompany busCompany = busCompanyService.GetBusCompanyByName(busCompanyName);

            if (customer == null || busCompany == null)
            {
                throw new ArgumentException($"Incorecet parameters!");
            }

            this.reviewService.AddReview(content, grade, busCompany, customer);

            return $"Customer {customer.FirstName} {customer.LastName} published review for company {busCompany.Name}";
        }
    }
}