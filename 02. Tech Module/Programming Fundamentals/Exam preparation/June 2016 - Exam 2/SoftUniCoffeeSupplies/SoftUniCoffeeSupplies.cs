using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftUniCoffeeSupplies
{
    class SoftUniCoffeeSupplies
    {
        private static string[] delimeters;

        private static Dictionary<string, string> team = new Dictionary<string, string>();

        private static Dictionary<string, long> coffees = new Dictionary<string, long>();

        private static void AddTeamMembers(string name, string coffee)
        {
            if (team.ContainsKey(name))
            {
                team[name] = coffee;
            }
            else
            {
                team.Add(name, coffee);
            }
            AddCoffee(coffee);
        }

        private static void AddCoffee(string name)
        {
            if (!coffees.ContainsKey(name))
            {
                coffees.Add(name, 0);
            }

        }

        private static void AddQantity(string name, long quantity)
        {
            if (coffees.ContainsKey(name))
            {

                coffees[name] += quantity;
            }
            else
            {
                coffees.Add(name, quantity);
            }
        }

        private static void CheckForOutOfQuantity()
        {
            foreach (var coffee in coffees)
            {
                if (coffee.Value <= 0)
                {
                    Console.WriteLine($"Out of {coffee.Key}");
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine("Coffee Left:");
            var coffeeLeft = coffees.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);

            foreach (var coffee in coffeeLeft)
            {
                Console.WriteLine($"{coffee.Key} {coffee.Value}");
            }

            Console.WriteLine("For:");
            foreach (var member in team.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                if (coffeeLeft.ContainsKey(member.Value))
                {
                    Console.WriteLine($"{member.Key} {member.Value}");
                }
            }
        }

        private static bool TakeInfo()
        {
            string input = Console.ReadLine();
            if (input == "end of info")
            {
                return false;
            }

            if (input.Contains(delimeters[0]))
            {
                int index = input.IndexOf(delimeters[0]);

                string name = input.Substring(0, index);
                string coffee = input.Substring(index + delimeters[0].Length);
                AddTeamMembers(name, coffee);
            }
            else if (input.Contains(delimeters[1]))
            {
                int index = input.IndexOf(delimeters[1]);
                string coffee = input.Substring(0, index);
                long counts = long.Parse(input.Substring(index + delimeters[1].Length));
                AddQantity(coffee, counts);
            }

            return true;
        }

        private static bool TakeCounts()
        {
            string input = Console.ReadLine();
            if (input == "end of week")
            {
                return false;
            }

            string[] array = input.Split(' ').Select(p => p.Trim()).ToArray();
            string name = array[0];
            long count = long.Parse(array[1]);
            if (!team.ContainsKey(name))
            {
                return true;
            }
            string coffeeType = team[name];
            if (!coffees.ContainsKey(coffeeType))
            {
                return true;
            }
            long quantity = coffees[coffeeType];

            if (quantity - count <= 0)
            {
                Console.WriteLine($"Out of {coffeeType}");
                coffees[coffeeType] = 0;
            }
            else
            {
                coffees[coffeeType] -= count;
            }

            return true;
        }

        static void Main(string[] args)
        {
            delimeters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (TakeInfo()) { }
            CheckForOutOfQuantity();
            while (TakeCounts()) { };
            Print();

        }
    }

}
