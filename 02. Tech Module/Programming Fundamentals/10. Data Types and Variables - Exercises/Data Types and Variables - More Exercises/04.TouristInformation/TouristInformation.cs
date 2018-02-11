using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TouristInformation
{
    class TouristInformation
    {
        static Dictionary<string, KeyValuePair<double,string>> conversionTable = new Dictionary<string, KeyValuePair<double, string>>
        {
            {"miles",new KeyValuePair<double, string>(1.6, "kilometers")},
            {"inches",new KeyValuePair<double, string>(2.54, "centimeters")},
            {"feet",new KeyValuePair<double, string>(30, "centimeters")},
            {"yards", new KeyValuePair<double, string>(0.91, "meters") },
            {"gallons",new KeyValuePair<double, string>(3.8, "liters")},
        };
        static void Main(string[] args)
        {
            string imperialUnit = Console.ReadLine();
            double value = double.Parse(Console.ReadLine());

            Console.WriteLine($"{value} {imperialUnit} = {String.Format("{0:0.00}",value*conversionTable[imperialUnit].Key)} {conversionTable[imperialUnit].Value}");
        }
    }
}
