using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetherRealms
{
    class NetherRealms
    {
        private static List<Demon> demons = new List<Demon>();

        private static void GetHealth(string name, out int health)
        {
            string pattern = @"([^0-9\+\-\*\/\.])";
            string[] charsFromName = Regex.Matches(name, pattern).Cast<Match>()
                .Select(a => a.Value).ToArray();

            health = 0;
            foreach (string c in charsFromName)
            {
                health += (int)c[0];
            }
        }

        private static void GetDamage(string name, out double damage)
        {
            string pattern = @"(\+?\-?\d+\.?\d*)";

            double[] number = Regex.Matches(name, pattern).Cast<Match>()
                                                        .Select(a => double.Parse(a.Value))
                                                        .ToArray();
            damage = 0;
            foreach (double num in number)
            {
                damage += num;
            }

            string multiplyOrDividePattern = @"(\*|\/)";
            string[] operators = Regex.Matches(name, multiplyOrDividePattern).Cast<Match>()
                                                                             .Select(a => a.Value)
                                                                             .ToArray();
            foreach (string o in operators)
            {
                if (o == "*")
                {
                    damage *= 2;
                }
                else if (o == "/")
                {
                    damage /= 2;
                }
            }
        }

        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(p => p.Trim())
                                    .ToArray();

            foreach (string name in names)
            {
                GetHealth(name, out int health);
                GetDamage(name, out double damage);
                demons.Add(new Demon(name, health, damage));
            }

            foreach (Demon demon in demons.OrderBy(x => x.Name))
            {
                demon.Print();
            }
        }
    }

    class Demon
    {
        private string name;
        private int health;
        private double damage;

        public Demon(string name, int health, double damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }

        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }
        public double Damage { get => damage; set => damage = value; }

        public void Print()
        {
            Console.WriteLine($"{this.name} - {this.health} health, {this.damage:F2} damage");
        }
    }
}
