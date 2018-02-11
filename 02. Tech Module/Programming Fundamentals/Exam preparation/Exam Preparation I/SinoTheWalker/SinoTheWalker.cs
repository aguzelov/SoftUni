using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoTheWalker
{
    class SinoTheWalker
    {
        /*
         12:00:00
         2147483647
         2147483647
         */

        static void Main(string[] args)
        {
            string[] timeArray = Console.ReadLine().Split(':').ToArray();
            long hours = long.Parse(timeArray[0]);
            long minutes = long.Parse(timeArray[1]);
            long seconds = long.Parse(timeArray[2]);

            long steps = long.Parse(Console.ReadLine());
            long secondForOneStep = long.Parse(Console.ReadLine());

            long totalTime = steps * secondForOneStep;

            seconds +=totalTime % 60;
            if (seconds > 59)
            {
                seconds -= 60;
                minutes++;
            }
            totalTime /= 60;

            minutes += totalTime % 60;
            if (minutes > 59)
            {
                minutes -= 60;
                hours++;
            }
            totalTime /= 60;

            hours += totalTime % 24;
            if (hours > 23)
            {
                hours %= 24;
            }


            var today = DateTime.Today;
            DateTime time = new DateTime(today.Year, today.Month, today.Day, (int)hours, (int)minutes, (int)seconds);

            Console.WriteLine("Time Arrival: " + time.ToString("HH:mm:ss"));
        }
    }
}
