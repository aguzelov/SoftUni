using BusTickets.Models;
using System;
using System.Globalization;

namespace BusTickets.Initializer.Generators
{
    public class TripGenerator
    {
        public static Trip[] GenerateTrips(BusStation[] stations, BusCompany[] companies)
        {
            Trip[] trips = new Trip[stations.Length];

            Random random = new Random();

            for (int i = 0; i < trips.Length; i++)
            {
                int day = random.Next(1, 28);
                int month = random.Next(1, 12);
                int year = random.Next(1990, 2015);

                DateTime date = DateTime.ParseExact($"{day}-{month}-{year}", "d-M-yyyy", CultureInfo.InvariantCulture);

                trips[i] = new Trip
                {
                    DepartureTime = date,
                    ArrivalTime = date.AddDays(random.Next(0, 100000)),

                    Status = (Status)random.Next(0, 3),

                    OriginBusStation = stations[i],
                    DestinationBusStation = stations[(stations.Length - 1) - i],

                    BusCompany = companies[i]
                };
            }

            return trips;
        }
    }
}