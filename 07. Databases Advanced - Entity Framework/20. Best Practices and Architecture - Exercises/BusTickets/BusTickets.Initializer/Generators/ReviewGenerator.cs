using BusTickets.Models;
using System;

namespace BusTickets.Initializer.Generators
{
    public class ReviewGenerator
    {
        public static Review[] GenerateReviews(BusCompany[] companies, Customer[] customers)
        {
            Review[] reviews = new Review[customers.Length];

            Random random = new Random();

            for (int i = 0; i < reviews.Length; i++)
            {
                string content = "Content: " + i;
                reviews[i] = new Review
                {
                    Content = content,
                    Grade = random.Next(1, 10),
                    BusCompany = companies[i],
                    Customer = customers[i],
                    PublishingDate = DateTime.Now
                };
            }

            return reviews;
        }
    }
}