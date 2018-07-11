using BusTickets.Models;

namespace BusTickets.Initializer.Generators
{
    internal class TownGenerator
    {
        public static Town[] GenerateTowns()
        {
            Town[] towns = new Town[3];

            for (int i = 0; i < 3; i++)
            {
                towns[i] = new Town
                {
                    Name = "TownName: " + i,
                    Country = "CountryName: " + i
                };
            }

            return towns;
        }
    }
}