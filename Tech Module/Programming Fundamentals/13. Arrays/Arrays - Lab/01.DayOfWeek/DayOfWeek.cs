using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DayOfWeek
{
    class DayOfWeek
    {
        static string[] dayOfWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        static void Main(string[] args)
        {
            int dayNumber = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(dayOfWeek[dayNumber - 1]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}
