using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxSumAverage
{
    class MinMaxSumAverage
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();
                numbers.Add(int.Parse(value));
            }

            int sum = numbers.Sum();
            int min = numbers.Min(entry => entry);
            int max = numbers.Max(entry => entry);
            int first = numbers[0];
            int last = numbers[numbers.Count-1];
            double average = numbers.Average();

            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Min = " + min);
            Console.WriteLine("Max = " + max);
            Console.WriteLine("Average = " + average);
        }
    }
}
