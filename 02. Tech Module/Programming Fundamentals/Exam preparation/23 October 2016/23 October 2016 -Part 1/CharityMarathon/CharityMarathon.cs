using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityMarathon
{
    class CharityMarathon
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int runners = int.Parse(Console.ReadLine());
            int averageLaps = int.Parse(Console.ReadLine());
            int lengthOfTrack = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            decimal moneyPerKilometer = decimal.Parse(Console.ReadLine());

            decimal money = 0;
            if (capacity * days >= runners)
            {
                long totalMeters = runners * averageLaps * (long)lengthOfTrack;
                long totalKm = totalMeters / 1000;
                money = totalKm * moneyPerKilometer;
            }
            else
            {
                runners = capacity * days;
                long totalMeters = runners * averageLaps * (long)lengthOfTrack;
                long totalKm = totalMeters / 1000;
                money = totalKm * moneyPerKilometer;
            }

            Console.WriteLine($"Money raised: {money:F2}");
        }
    }
}