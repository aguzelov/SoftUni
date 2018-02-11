using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.GrabAndGo
{
    class GrabAndGo
    {
        static void Main(string[] args)
        {
            ReadArray(out int[] array);

            int searchNumber = int.Parse(Console.ReadLine());

            int endIndex = Array.LastIndexOf(array, searchNumber);
            if (endIndex < 0)
            {
                Console.WriteLine("No occurrences were found!");
                return;
            }
            long sum = 0;

            for (int i = 0; i < endIndex; i++)
            {
                sum += array[i];
            }

            Console.WriteLine(sum);
        }

        static void ReadArray(out int[] array)
        {
            array = Console.ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();
        }
    }
}
