using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Weather
{
    class Weather
    {
        private static List<Data> list = new List<Data>();

        private static bool TakeLine()
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                PrintData();
                return false;
            }

            string pattern = @"(?<city>[A-Z]{2})(?<temperature>[0-9]+\.[0-9]+)(?<type>[A-Za-z]+)(?=\|)";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(input);

            if (match.Success)
            {
                string city = match.Groups["city"].Value;
                string temperature = match.Groups["temperature"].Value;
                string type = match.Groups["type"].Value;

                if (list.Any(x => x.City == city))
                {
                    Data data = list.Find(x => x.City == city);
                    data.Temperature = temperature;
                    data.Type = type;
                }
                else
                {
                    list.Add(new Data(city, temperature, type));
                }
            }
            return true;
        }

        private static void PrintData()
        {
            foreach (Data data in list.OrderBy(x => x.Temperature))
            {
                data.PrintInfo();
            }
        }

        static void Main(string[] args)
        {
            while (TakeLine()) { }
        }
    }

    class Data
    {
        private string city;
        private string temperature;
        private string type;

        public Data(string city, string temperature, string type)
        {
            this.city = city;
            this.temperature = temperature;
            this.type = type;
        }

        public string City { get => city; set => city = value; }
        public string Temperature { get => temperature; set => temperature = value; }
        public string Type { get => type; set => type = value; }

        public void PrintInfo()
        {
            Console.WriteLine($"{city} => {double.Parse(temperature):F2} => {type}");
        }
    }
}
