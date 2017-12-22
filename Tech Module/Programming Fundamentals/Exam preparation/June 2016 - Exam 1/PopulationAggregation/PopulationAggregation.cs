using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PopulationAggregation
{
    class PopulationAggregation
    {
        private static Dictionary<string, List<string>> countries = new Dictionary<string, List<string>>();
        private static Dictionary<string, long> cities = new Dictionary<string, long>();

        private static void Add(string country, string city, long population)
        {
            if (countries.ContainsKey(country))
            {
                countries[country].Add(city);
            }
            else
            {
                countries.Add(country, new List<string> { city });
            }

            if (cities.ContainsKey(city))
            {
                cities[city] = population;
            }
            else
            {
                cities.Add(city, population);
            }
        }

        private static bool TakeInput()
        {
            string input = Console.ReadLine();
            if (input == "stop")
            {
                Print();
                return false;
            }

            string[] array = input.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string countryName;
            string cityName;
            long population;
            if (char.IsUpper(array[0][0]))
            {
                countryName = Regex.Replace(array[0], @"[\@\#\$\&0-9]", "");
                cityName = Regex.Replace(array[1], @"[\@\#\$\&0-9]", "");
                population = long.Parse(array[2]);
            }
            else
            {
                cityName = Regex.Replace(array[0], @"[\@\#\$\&0-9]", "");
                countryName = Regex.Replace(array[1], @"[\@\#\$\&0-9]", "");
                population = long.Parse(array[2]);
            }
            Add(countryName, cityName, population);

            return true;
        }

        private static void Print()
        {
            foreach (var pair in countries.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value.Count}");
            }

            foreach (var pair in cities.OrderByDescending(x => x.Value).Take(3))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        static void Main(string[] args)
        {
            while (TakeInput()) { }
        }
    }
}
