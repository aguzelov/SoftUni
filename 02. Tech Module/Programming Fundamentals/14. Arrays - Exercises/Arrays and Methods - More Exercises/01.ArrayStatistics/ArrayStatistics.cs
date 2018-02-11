using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ArrayStatistics
{
    class ArrayStatistics
    {
        static int[] ReadArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }


        static void Main(string[] args)
        {
            int[] array = ReadArray();

            int minValue = int.MaxValue;
            int maxValue = int.MinValue;

            int sum = 0;
            double average = 0.0;

            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] < minValue)
                {
                    minValue = array[i];
                }

                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
                sum += array[i];
            }

            Console.WriteLine("Min = " + minValue);
            Console.WriteLine("Max = " + maxValue);
            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Average = {0}",sum/(double)array.Length);
        }
    }
}
