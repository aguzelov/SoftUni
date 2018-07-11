using BusTickets.Data;
using BusTickets.Models;
using BusTickets.Services.Contracts;
using System;
using System.Linq;

namespace BusTickets.Services
{
    public class ReviewService : IReviewService
    {
        private readonly BusTicketsContext context;

        public ReviewService(BusTicketsContext context)
        {
            this.context = context;
        }

        public void AddReview(string content, float grade, BusCompany busCompany, Customer customer)
        {
            Review review = new Review
            {
                Content = content,
                Grade = grade,
                BusCompany = busCompany,
                Customer = customer,
                PublishingDate = DateTime.Now
            };

            context.Reviews.Add(review);

            context.SaveChanges();
        }

        public Review[] GetReviewByBusCompanyId(int id)
        {
            Review[] review = context.Reviews
                .Where(r => r.BusCompanyId == id)
                .ToArray();

            return review;
        }

        public Review GetReviewById(int id)
        {
            Review review = context.Reviews.FirstOrDefault(r => r.ReviewId == id);

            return review;
        }
    }
}