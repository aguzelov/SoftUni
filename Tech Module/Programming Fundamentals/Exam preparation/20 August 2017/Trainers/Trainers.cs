using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainers
{
    class Trainers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int distance = int.Parse(Console.ReadLine());
                decimal cargo = decimal.Parse(Console.ReadLine());
                string name = Console.ReadLine();
                new Team(distance, cargo, name);
            }

            Team.Print();
        }
    }
    class Team
    {
        private static Dictionary<string, decimal> total = new Dictionary<string, decimal>
        {
            {"Technical", 0 },
            {"Theoretical", 0 },
            {"Practical" , 0 }
        };

        private int distanceMeters;
        private decimal cargoInKg;

        private decimal fuelConsumption;
        private decimal cargoPrice;

        protected decimal earnedMoney;

        public Team(int distance, decimal cargo, string teamType)
        {
            this.distanceMeters = distance * 1600;
            this.cargoInKg = cargo * 1000;

            this.fuelConsumption = ((decimal)0.7 * distanceMeters) * (decimal)2.5;
            this.cargoPrice = (decimal)1.5 * cargoInKg;

            this.earnedMoney = cargoPrice - fuelConsumption;

            total[teamType] += earnedMoney;
        }

        public static void Print()
        {
            KeyValuePair<string, decimal> top = total.OrderByDescending(x => x.Value).First();
            Console.WriteLine($"The {top.Key} Trainers win with ${top.Value:F3}.");
        }
    }

}
