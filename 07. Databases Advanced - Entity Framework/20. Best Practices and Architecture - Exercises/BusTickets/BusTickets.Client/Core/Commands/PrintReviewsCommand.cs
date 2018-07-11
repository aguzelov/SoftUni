using BusTickets.Models;
using BusTickets.Services.Contracts;
using System;
using System.Text;

namespace BusTickets.Client.Core.Commands
{
    public class PrintReviewsCommand : ICommand
    {
        private readonly IReviewService reviewService;
        private readonly ICustomerService customerService;

        public PrintReviewsCommand(IReviewService reviewService, ICustomerService customerService)
        {
            this.reviewService = reviewService;
            this.customerService = customerService;
        }

        public string Execute(string[] data)
        {
            int busCompanyId = int.Parse(data[0]);

            Review[] reviews = reviewService.GetReviewByBusCompanyId(busCompanyId);

            var sb = new StringBuilder();

            foreach (var review in reviews)
            {
                int id = review.ReviewId;
                float grade = review.Grade;
                DateTime publishDateTime = review.PublishingDate;

                int customerId = review.CustomerId;
                Customer customer = customerService.GetCustomerById(customerId);
                string fullName = customer.FirstName + " " + customer.LastName;

                string content = review.Content;

                sb.AppendLine($"{id} {grade} {publishDateTime.ToString("dd-MM-yyyy")}");
                sb.AppendLine($"{fullName}");
                sb.AppendLine($"{ content}");
            }

            return sb.ToString();
        }
    }
}