using BusTickets.Models;
using System;

namespace BusTickets.Initializer.Generators
{
    public class CustomerGenerator
    {
        public static Customer[] GenerateCustomers(Town[] towns)
        {
            Random random = new Random();

            Customer[] customers = new Customer[3];

            for (int i = 0; i < 3; i++)
            {
                string firstName = "FirstName:" + i;
                string lastName = "LastName:" + i;
                DateTime BirthDate = DateTime.Now;

                customers[i] = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = BirthDate,
                    Gender = (Gender)random.Next(0, 2),
                    HomeTown = towns[i]
                };
            }

            return customers;
        }
    }
}