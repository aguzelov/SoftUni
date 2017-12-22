using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class PopulationCounter
    {
        static List<Country> countrys = new List<Country>();

        static void Report()
        {
            var sorted = countrys.OrderByDescending(x => x.TotalPopulation)
                                 .ToList();

            foreach (Country c in sorted)
            {
                c.Report();
            }
        }

        static bool TakeInput()
        {
            //city|country|populations
            // [0]   [1]      [2]
            //report
            string[] input = Console.ReadLine()
                                .Split('|')
                                .Where(p => !string.IsNullOrWhiteSpace(p))
                                .ToArray();

            if (input[0] == "report")
            {
                Report();
                return false;
            }

            string city = input[0];
            string country = input[1];
            long population = long.Parse(input[2]);

            if (countrys.Any(c => c.Name == country))
            {
                Country currentCountry = countrys.FirstOrDefault(c => c.Name == country);
                currentCountry.AddCity(city, population);
            }
            else
            {
                countrys.Add(new Country(country, city, population));
            }
            
            return true;
        }

        static void Main(string[] args)
        {
            while (TakeInput())
            {

            }
        }
    }

    class Country
    {
        private string name;
        private long totalPopulation;

        private Dictionary<string, long> citys = new Dictionary<string, long> { };

        public Country(string name)
        {
            this.name = name;
            this.totalPopulation = 0;
        }

        public Country(string countryName, string cityName, long population)
        {
            this.name = countryName;
            this.totalPopulation = 0;
            AddCity(cityName, population);
        }

        public string Name { get => name; set => name = value; }
        public long TotalPopulation { get => totalPopulation; }

        public void AddCity(string city, long population)
        {
            this.totalPopulation += population;
            if (citys.ContainsKey(city))
            {
                citys[city] += population;
            }
            else
            {
                citys.Add(city, population);
            }
        }

        public void Report()
        {
            Console.WriteLine($"{this.name} (total population: {this.totalPopulation})");

            var sorted = citys.OrderByDescending(x => x.Value)
                               .ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, long> pair in sorted)
            {
                Console.WriteLine($"=>{pair.Key}: {pair.Value}");
            }

        }

    }
}
