using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SinoTheWalker
{
    class SinoTheWalker
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);

            BigInteger steps = new BigInteger(int.Parse(Console.ReadLine()));
            BigInteger timeForOneStep = new BigInteger(int.Parse(Console.ReadLine()));

            BigInteger time = steps * timeForOneStep;

            int seconds = (int)(time % 60);
            int minutes = (int)(time / 60 % 60);
            int hours = (int)(time / 60 / 60 % 24);

            date = date.AddSeconds(seconds);
            date = date.AddMinutes(minutes);
            date = date.AddHours(hours);

            Console.WriteLine($"Time Arrival: {date.Hour:00}:{date.Minute:00}:{date.Second:00}");

        }
    }
}
