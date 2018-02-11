using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetWings
{
    class HornetWings
    {
        static void Main(string[] args)
        {
            decimal wingFlaps = decimal.Parse(Console.ReadLine());

            decimal distanceTravelFor1000WingFlaps = decimal.Parse(Console.ReadLine());

            decimal endurance = decimal.Parse(Console.ReadLine());

            decimal distance = (wingFlaps / 1000) * distanceTravelFor1000WingFlaps;

            long totalSeconds = (long)wingFlaps / 100;

            totalSeconds += (long)(wingFlaps / endurance) * 5;

            Console.WriteLine($"{distance:F2} m.");
            Console.WriteLine($"{totalSeconds} s.");
        }
    }
}
