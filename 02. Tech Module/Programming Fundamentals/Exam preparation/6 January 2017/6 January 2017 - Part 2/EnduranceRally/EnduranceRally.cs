using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduranceRally
{
    class EnduranceRally
    {

        static void Main(string[] args)
        {
            List<Drivers> drivers = Console.ReadLine()
                                          .Split(' ')
                                          .Select(n => new Drivers(n))
                                          .ToList();


            double[] track = Console.ReadLine()
                           .Split(' ')
                           .Select(double.Parse)
                           .ToArray();

            int[] checkpoints = Console.ReadLine()
                                       .Split(' ')
                                       .Select(int.Parse)
                                       .ToArray();

            for (int i = 0; i < track.Length; i++)
            {
                if (checkpoints.Contains(i))
                {
                    drivers.ForEach(x => x.AddFuel(track[i], i));
                }
                else
                {
                    drivers.ForEach(x => x.AddFuel((track[i] * (-1)), i));
                }
            }

            drivers.ForEach(x => x.Print());

        }
    }

    class Drivers
    {
        private string name;
        private double fuel;
        private int checkpoint;
        public Drivers(string name)
        {
            this.name = name;
            this.fuel = (int)name[0];
        }

        public string Name { get => name; set => name = value; }
        public double Fuel { get => fuel; set => fuel = value; }

        public void AddFuel(double fuel, int checkpoint)
        {
            if (this.fuel > 0)
            {
                this.fuel += fuel;
                this.checkpoint = checkpoint;
            }
        }

        public void Print()
        {
            if (this.fuel > 0)
            {
                Console.WriteLine($"{this.name} - fuel left {this.fuel:F2}");
            }
            else
            {
                Console.WriteLine($"{this.name} - reached {this.checkpoint}");
            }
        }
    }
}
