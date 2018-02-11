using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniWaterSupplies
{
    class SoftUniWaterSupplies
    {
        private static double totalAmountWater;
        private static int capacity;

        private static List<double> bottles = new List<double>();
        private static List<int> indexes = new List<int>();
        private static double litersNeed;

        private static void FromStart()
        {
            for (int i = 0; i < bottles.Count; i++)
            {
                double waterToFill = capacity - bottles[i];
                if (waterToFill <= totalAmountWater)
                {
                    totalAmountWater -= waterToFill;
                }
                else
                {
                    if (totalAmountWater > 0)
                    {
                        litersNeed += capacity - bottles[i] - totalAmountWater;
                        totalAmountWater = 0;
                    }
                    else
                    {
                        litersNeed += capacity - bottles[i];
                    }
                    indexes.Add(i);

                }
            }
            PrintResult();
        }

        private static void FromEnd()
        {
            for (int i = bottles.Count - 1; i >= 0; i--)
            {
                double waterToFill = capacity - bottles[i];
                if (waterToFill <= totalAmountWater)
                {
                    totalAmountWater -= waterToFill;
                }
                else
                {
                    if (totalAmountWater > 0)
                    {
                        litersNeed += capacity - bottles[i] - totalAmountWater;
                        totalAmountWater = 0;
                    }
                    else
                    {
                        litersNeed += capacity - bottles[i];
                    }
                    indexes.Add(i);
                }
            }
            PrintResult();
        }

        private static void PrintResult()
        {
            if (indexes.Count != 0)
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine($"Bottles left: {indexes.Count}");
                Console.WriteLine($"With indexes: {string.Join(", ", indexes)}");
                Console.WriteLine($"We need {litersNeed} more liters!");
            }
            else
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {totalAmountWater}l.");
            }
        }

        static void Main(string[] args)
        {
            totalAmountWater = double.Parse(Console.ReadLine());

            bottles = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            capacity = int.Parse(Console.ReadLine());

            if (totalAmountWater % 2 == 0)
            {
                FromStart();
            }
            else
            {
                FromEnd();
            }

        }
    }
}
