using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
    class DragonArmy
    {
        static Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>> { };
        
        static void TakeInput()
        {
            string[] input = Console.ReadLine()
                                    .Split(' ')
                                    .Where(p => !string.IsNullOrWhiteSpace(p))
                                    .ToArray();

            string type = input[0];
            string name = input[1];
            string damage = input[2];
            string health = input[3];
            string armor = input[4];

            if (dragons.ContainsKey(type))
            {
                if (dragons[type].Any(x => x.Name == name))
                {
                    int index = dragons[type].FindIndex(x => x.Name == name);
                    dragons[type][index] = new Dragon(name, damage, health, armor);
                }
                else
                {
                    dragons[type].Add(new Dragon(name, damage, health, armor));
                }
            }
            else
            {
                dragons.Add(type, new List<Dragon>() { new Dragon(name, damage, health, armor) });
            }

        }

        static void Print()
        {
            foreach (var dragon in dragons)
            {
                double averageDamage = dragon.Value.Average(t => t.Damage);
                double averageHealth = dragon.Value.Average(t => t.Health);
                double averageArmor = dragon.Value.Average(t => t.Armor);

                Console.WriteLine($"{dragon.Key}::({string.Format("{0:0.00}",averageDamage)}/{string.Format("{0:0.00}", averageHealth)}/{string.Format("{0:0.00}", averageArmor)})");

                var sorted = dragon.Value.OrderBy(x => x.Name).ToList();
                foreach (Dragon d in sorted)
                {
                    d.PrintInfo();
                }
            }
        }



        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                TakeInput();
            }
            Print();
        }
    }

    class Dragon
    {
        private string name;
        private int damage;
        private int health;
        private int armor;

        public Dragon(string name, string damage, string health, string armor)
        {
            this.name = name;
            this.damage = (damage == "null") ? 45 : int.Parse(damage);
            this.health = (health == "null") ? 250 : int.Parse(health);
            this.armor = (armor == "null") ? 10 : int.Parse(armor);

        }

        public string Name { get => name; set => name = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Health { get => health; set => health = value; }
        public int Armor { get => armor; set => armor = value; }

        public void PrintInfo()
        {
            Console.WriteLine($"-{this.name} -> damage: {this.damage}, health: {this.health}, armor: {this.armor}");
        }
    }
}
