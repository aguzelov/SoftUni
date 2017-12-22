using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EqualSums
{
    class EqualSums
    {
        static int[] ReadArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        static int SumElementsInSubarray(int[] array, int startIndex, int endIndex)
        {
            int sum = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        static void Main(string[] args)
        {
            int[] elements = ReadArray();

            bool isFound = false;

            for (int i = 0; i < elements.Length; i++)
            {

                if (SumElementsInSubarray(elements, 0, i) == SumElementsInSubarray(elements, i + 1, elements.Length))
                {
                    isFound = true;
                    Console.WriteLine(i);
                }
            }

            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
