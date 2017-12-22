using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trainlands
{
    class Trainlands
    {
        private static Dictionary<string, List<Wagon>> trains = new Dictionary<string, List<Wagon>>();

        static void Main(string[] args)
        {
            while (TakeLine())
            {
            }
        }

        private static bool TakeLine()
        {
            string input = Console.ReadLine();
            if (input == "It's Training Men!")
            {
                Print();
                return false;
            }

            string createPattern = @"^((?<trainName>[^\s\-\:\>\=]+) -> (?<wagonName>[^\s\-\:\>\=]+) : (?<wagonPower>[0-9]+))$";
            string addPattern = @"^((?<first>[^\s\-\:\>\=]+) -> (?<second>[^\s\-\:\>\=]+))$";
            string copyPattern = @"^((?<first>[^\s\-\:\>\=]+) = (?<second>[^\s\-\:\>\=]+))$";

            if (Regex.IsMatch(input, createPattern))
            {
                Match match = Regex.Match(input, createPattern);
                string trainName = match.Groups["trainName"].Value;
                string wagonName = match.Groups["wagonName"].Value;
                long wagonPower = long.Parse(match.Groups["wagonPower"].Value);

                Wagon wagon = new Wagon(wagonName, wagonPower);

                CreateTrain(trainName, wagon);
            }
            else if (Regex.IsMatch(input, addPattern))
            {
                Match match = Regex.Match(input, addPattern);
                string first = match.Groups["first"].Value;
                string second = match.Groups["second"].Value;
                AddAll(first, second);
            }
            else if (Regex.IsMatch(input, copyPattern))
            {
                Match match = Regex.Match(input, copyPattern);
                string first = match.Groups["first"].Value;
                string second = match.Groups["second"].Value;
                Copy(first, second);
            }

            return true;
        }

        private static void Print()
        {
            var sorted = trains.OrderByDescending(x => x.Value.Sum(y => y.Power)).ThenBy(x => x.Value.Count);

            foreach (var pair in sorted)
            {
                Console.WriteLine($"Train: {pair.Key}");
                foreach (Wagon wagon in pair.Value.OrderByDescending(x => x.Power))
                {
                    Console.WriteLine($"###{wagon.Name} - {wagon.Power}");
                }
            }
        }

        private static void CreateTrain(string name, Wagon wagon)
        {
            if (trains.ContainsKey(name))
            {
                trains[name].Add(wagon);
            }
            else
            {
                trains.Add(name, new List<Wagon> { wagon });
            }
        }

        private static void AddAll(string name, string otherName)
        {
            List<Wagon> otherWagons = trains[otherName];
            if (trains.ContainsKey(name))
            {
                trains[name].AddRange(otherWagons);

                trains[otherName] = null;
                trains.Remove(otherName);
            }
            else
            {
                trains.Add(name, new List<Wagon>());
                trains[name].AddRange(otherWagons);

                trains[otherName] = null;
                trains.Remove(otherName);
            }
        }

        private static void Copy(string name, string otherName)
        {
            List<Wagon> otherWagons = trains[otherName];

            if (trains.ContainsKey(name))
            {
                trains[name].Clear();
                trains[name].AddRange(otherWagons);
            }
            else
            {
                trains.Add(name, new List<Wagon>());
                trains[name].AddRange(otherWagons);
            }
        }
    }

    class Wagon
    {
        private string name;
        private long power;

        public Wagon(string name, long power)
        {
            this.name = name;
            this.power = power;
        }

        public string Name { get => name; set => name = value; }
        public long Power { get => power; set => power = value; }
    }
}
