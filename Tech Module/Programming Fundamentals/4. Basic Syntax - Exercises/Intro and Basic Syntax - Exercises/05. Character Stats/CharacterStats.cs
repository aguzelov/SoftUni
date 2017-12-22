using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Character_Stats
{
    class CharacterStats
    {
        string name;
        int currentHealth;
        int maxHealth;
        int currentEnergy;
        int maxEnergy;

        public string Name { get => name; set => name = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int CurrentEnergy { get => currentEnergy; set => currentEnergy = value; }
        public int MaxEnergy { get => maxEnergy; set => maxEnergy = value; }

        CharacterStats(string name, int currH, int maxH, int currE, int maxE)
        {
            this.Name = name;
            this.CurrentHealth = currH;
            this.MaxHealth = maxH;
            this.CurrentEnergy = currE;
            this.MaxEnergy = maxE;
        }
        string setBar(int curr, int max)
        {
            string bar = "|";
            for(int i = 0; i < curr; i++)
            {
                bar += "|";
            }
            for(int i = 0; i < max-curr; i++)
            {
                bar += ".";
            }
            bar += "|";
            return bar;
        }
        void printBar()
        {
            Console.WriteLine("Name: " + this.Name);
            Console.WriteLine("Health: " + setBar(this.CurrentHealth, this.MaxHealth));
            Console.WriteLine("Energy: " + setBar(this.CurrentEnergy, this.MaxEnergy));
        }
        static void Main(string[] args)
        {
            CharacterStats stats = new CharacterStats(Console.ReadLine(), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            stats.printBar();
        }
    }
}
