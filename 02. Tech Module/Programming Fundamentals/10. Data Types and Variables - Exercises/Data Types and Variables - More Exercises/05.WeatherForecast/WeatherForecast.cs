using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.WeatherForecast
{
    class WeatherForecast
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            

            if(sbyte.TryParse(input, out var sbyteValue))
            {
                Console.WriteLine("Sunny");
            }else if (int.TryParse(input, out int intValue))
            {
                Console.WriteLine("Cloudy");
            }
            else if (long.TryParse(input, out long longValue))
            {
                Console.WriteLine("Windy");
            }
            else if (double.TryParse(input, out double doubleValue))
            {
                Console.WriteLine("Rainy");
            }
        }
    }
}
