using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Test_Numbers
{
    class TestNumbers
    {
        static int totalSum;
        static int maxBoundary;
        static int combinations;

        static void addToTotalSum(int value)
        {
            totalSum += value;
        }

        static bool isEqualOrGreater()
        {
            if (totalSum >= maxBoundary)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            maxBoundary = int.Parse(Console.ReadLine());

            for (int i = first; i >= 1; i--)
            {
                for (int j = 1; j <= second; j++)
                {
                    addToTotalSum(3 * (i * j));
                    combinations++;
                    if (isEqualOrGreater())
                    {
                        Console.WriteLine($"{combinations} combinations");
                        Console.WriteLine($"Sum: {totalSum} >= {maxBoundary}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{combinations} combinations");
            Console.WriteLine($"Sum: {totalSum}");
        }
    }
}
