using BusTickets.Models;
using System;

namespace BusTickets.Initializer.Generators
{
    public class BusStationGenerator
    {
        public static BusStation[] GenerateBusStations(Town[] towns)
        {
            Random random = new Random(200);

            BusStation[] stations = new BusStation[3];

            for (int i = 0; i < 3; i++)
            {
                stations[i] = new BusStation
                {
                    Name = "BUS-STATION: " + i,
                    Town = towns[i]
                };
            }

            return stations;
        }
    }
}