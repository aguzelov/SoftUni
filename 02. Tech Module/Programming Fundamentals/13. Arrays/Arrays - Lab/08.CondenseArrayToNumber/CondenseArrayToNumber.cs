using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CondenseArrayToNumber
{
    class CondenseArrayToNumber
    {
        static void Main(string[] args)
        {
            int[] array = Array.ConvertAll(
                                Console.ReadLine()
                                .Split(' ')
                                .Select(p => p.Trim())
                                .Where(p => !string.IsNullOrWhiteSpace(p))
                                .ToArray()
                                 , p => int.Parse(p));

            while (array.Length > 1)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    array[i] = array[i] + array[i + 1];
                }
                Array.Resize(ref array, array.Length - 1);
            }

            Console.Write(array[0]);

        }
    }
}
