using BusTickets.Models;
using System;

namespace BusTickets.Initializer.Generators
{
    public class BusCompanyGenerator
    {
        public static BusCompany[] GenerateBusCompanies()
        {
            BusCompany[] companies = new BusCompany[3];

            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                decimal rating = random.Next(1, 10);

                companies[i] = new BusCompany
                {
                    Name = "BUS-Company:" + i,
                    Nationality = "Nationality: " + i,
                    Rating = rating
                };
            }

            return companies;
        }
    }
}