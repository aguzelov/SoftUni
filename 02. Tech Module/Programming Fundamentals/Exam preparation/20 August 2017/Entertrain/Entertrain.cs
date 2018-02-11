using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertrain
{
    class Entertrain
    {
        private static List<int> train = new List<int>();
        private static int locomotivePower;
        static void Main(string[] args)
        {
            locomotivePower = int.Parse(Console.ReadLine());

            while (TakeWagons()) { }
        }

        private static bool TakeWagons()
        {
            string input = Console.ReadLine();
            if (input == "All ofboard!")
            {
                Print();
                return false;
            }

            int wagonWeight = int.Parse(input);

            train.Add(wagonWeight);
            if (train.Sum() > locomotivePower)
            {
                int averageWeight = (int)train.Average();
                int closest = train.Aggregate((x, y) => Math.Abs(x - averageWeight) < Math.Abs(y - averageWeight) ? x : y);
                train.Remove(closest);
            }

            return true;
        }

        private static void Print()
        {
            train.Reverse();
            train.Add(locomotivePower);
            Console.WriteLine(string.Join(" ", train));
        }
    }
}
