using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokemonEvolution
{
    class PokemonEvolution
    {
        private static List<Pokemon> pokemons = new List<Pokemon>();

        private readonly static string pattern = @"(^)(?<name>.+)(\s\-\>\s)(?<type>.+)(\s\-\>\s)(?<index>\d+)($)";

        private static void AddToPokemens(string name, string type, int index)
        {
            if (pokemons.Any(x => x.Name == name))
            {
                int i = pokemons.FindIndex(x => x.Name == name);
                pokemons[i].AddEvolution(type, index);
            }
            else
            {
                pokemons.Add(new Pokemon(name, type, index));
            }
        }

        private static bool TakeInput()
        {
            string input = Console.ReadLine();
            if (input == "wubbalubbadubdub")
            {
                pokemons.ForEach(x => x.PrintOrdered());
                return false;
            }

            if (!input.Contains("->"))
            {
                if (pokemons.Any(x => x.Name == input))
                {
                    int i = pokemons.FindIndex(x => x.Name == input);
                    pokemons[i].Print();
                }
                return true;
            }

            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                string name = match.Groups["name"].Value;
                string type = match.Groups["type"].Value;
                string index = match.Groups["index"].Value;
                AddToPokemens(name, type, int.Parse(index));
            }

            return true;
        }

        static void Main(string[] args)
        {
            while (TakeInput()) { }


        }
    }

    class Pokemon
    {
        private string name;
        private List<KeyValuePair<string, int>> evolution = new List<KeyValuePair<string, int>>();

        public Pokemon(string name, string type, int index)
        {
            this.name = name;
            this.evolution.Add(new KeyValuePair<string, int>(type, index));
        }

        public string Name { get => name; set => name = value; }

        public void AddEvolution(string type, int index)
        {
            this.evolution.Add(new KeyValuePair<string, int>(type, index));
        }

        public void Print()
        {
            Console.WriteLine($"# {this.name}");
            foreach (var pair in evolution)
            {
                Console.WriteLine($"{pair.Key} <-> {pair.Value}");
            }
        }

        public void PrintOrdered()
        {
            Console.WriteLine($"# {this.name}");
            foreach (var pair in evolution.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{pair.Key} <-> {pair.Value}");
            }
        }

    }
}
