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
            List<string> input = Console.ReadLine()
                                               .Split(' ')
                                               .ToList();

            double[] zones = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            int[] checkpoint = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < zones.Length; i++)
            {
                if (!checkpoint.Contains(i))
                {
                    zones[i] *= -1;
                }
            }

            List<Driver> drivers = new List<Driver>();

            foreach (string name in input)
            {
                drivers.Add(new Driver(name));
            }

            for (int i = 0; i < zones.Length; i++)
            {
                drivers.ForEach(x => x.RecieveFuel(zones[i], i));
            }

            foreach (Driver driver in drivers)
            {
                Console.WriteLine(driver.DriverInfo());

            }
        }
    }

    class Driver
    {
        private string name;
        private double fuel;
        private int reachedZoneIndex;

        public Driver(string name)
        {
            this.name = name;
            this.fuel = (double)name[0];
        }

        public void RecieveFuel(double fuel, int zoneIndex)
        {
            if (this.fuel > 0)
            {
                this.reachedZoneIndex = zoneIndex;
                this.fuel += fuel;
            }
        }

        public string DriverInfo()
        {
            if (fuel > 0)
            {
                return $"{name} - fuel left {string.Format("{0:0.00}", fuel)}";
            }
            else
            {
                return $"{name} - reached {reachedZoneIndex}";
            }

        }
    }
}
