using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Neighbour_Wars
{
    public class Neighbour
    {
        protected int Damage { get; set; }
        protected int health = 100;
        protected string Name { get; set; }
        protected string SignatureAttack { get; set; }

        public static int turnCounter = 1;
        public static bool IsFighting = true;

        static string[] NeighbourAttacks = new string[] { "Thunderous fist", "Roundhouse kick" };
        
        public Neighbour(string name, int damage)
        {
            this.Name = name;
            this.Damage = damage;
            this.SignatureAttack = this.Name == "Gosho" ? NeighbourAttacks[0] : NeighbourAttacks[1];
        }

        public void Attack(Neighbour other)
        {
            other.takeDamage(this.Damage);
            if (!other.IsAlive())
            {
                Console.WriteLine($"{this.Name} won in {turnCounter}th round.");
                IsFighting = false;
            }
            else
            {
                Console.WriteLine($"{this.Name} used {this.SignatureAttack} and reduced {other.Name} to {other.health} health.");
            }
           
            if (turnCounter%3 == 0)
            {
                this.Healing();
                other.Healing();
            }

            turnCounter++;
        }

        protected void takeDamage(int damage)
        {
            this.health -= damage;
        }

        protected bool IsAlive()
        {
            return this.health > 0 ? true : false;
        }

        protected void Healing()
        {
            this.health += 10;
        }
    }
    class NeighbourWars
    {
        static void Main(string[] args)
        {
            Neighbour pesho = new Neighbour("Pesho", int.Parse(Console.ReadLine()));
            Neighbour gosho = new Neighbour("Gosho", int.Parse(Console.ReadLine()));

            while (Neighbour.IsFighting)
            {
                if(Neighbour.turnCounter%2 == 0)
                {
                    //Gosho turn
                    gosho.Attack(pesho);
                }
                else
                {
                    //Pesho turn
                    pesho.Attack(gosho);
                }
            }
        }
    }
}
