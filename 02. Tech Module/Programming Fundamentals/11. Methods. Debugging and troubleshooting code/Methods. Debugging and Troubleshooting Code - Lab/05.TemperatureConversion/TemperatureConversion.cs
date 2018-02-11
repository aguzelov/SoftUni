using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.TemperatureConversion
{
    class TemperatureConversion
    {
        static double FahrenheitToCelsius(double temperature)
        {
            return (temperature - 32) * 5 / 9;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(String.Format("{0:0.00}",FahrenheitToCelsius(double.Parse(Console.ReadLine()))));
        }
    }
}
