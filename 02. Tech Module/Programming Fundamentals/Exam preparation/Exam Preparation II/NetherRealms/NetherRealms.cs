using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<Demon> demons = new List<Demon>();

            foreach (string name in input)
            {
                demons.Add(new Demon(name));
            }
            foreach (Demon demon in demons.OrderBy(n => n.Name))
            {
                Console.WriteLine(demon.PrintInfo());
            }
        }
    }

    class Demon
    {
        private string name;
        private long health;
        private decimal damage;

        private List<char> operators = new List<char>();

        public string Name { get => name; set => name = value; }

        public Demon(string name)
        {
            this.name = name;
            CalculateHealth();
            CalculateDamage();
        }


        private void CalculateHealth()
        {
            string pattern = @"[^\d\.\+\-\*\/\s\,]";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(this.name);
            foreach (Match match in matches)
            {
                foreach (char c in match.ToString())
                    this.health += (int)c;
            }
        }

        private void CalculateDamage()
        {
            string pattern = @"[\-\+]?[\d]+(?:[\.]*[\d]+|[\d]*)";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(this.name);
            foreach (Match match in matches)
            {
                this.damage += decimal.Parse(match.ToString());
            }

            SetOperators();
            foreach (char o in operators)
            {
                if (o == '*')
                {
                    this.damage *= 2;
                }
                else if (o == '/')
                {
                    this.damage /= 2;
                }
            }
        }

        private void SetOperators()
        {
            string pattern = @"[*/]";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(this.name);
            foreach (Match match in matches)
            {
                this.operators.Add(match.Value.ToCharArray()[0]);
            }
        }

        public string PrintInfo()
        {
            return $"{this.name} - {this.health} health, {string.Format("{0:0.00}", this.damage)} damage";
        }

    }
}
