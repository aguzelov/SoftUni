using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TripleSum
{
    class TripleSum
    {
        static void Main(string[] args)
        {
            string[] splitStringArray = Console.ReadLine().Split(' ').Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();

            int[] array = Array.ConvertAll(splitStringArray, s => int.Parse(s));

            for (int i = 0; i < splitStringArray.Length; i++)
            {
                array[i] = int.Parse(splitStringArray[i]);
            }

            bool isExist = false;
            for (int a = 0; a < array.Length - 1; a++)
            {
                for (int b = a + 1; b < array.Length; b++)
                {
                    if (array.Contains(array[a] + array[b]))
                    {
                        isExist = true;
                        Console.WriteLine($"{array[a]} + {array[b]} == {array[a] + array[b]}");
                    }
                }
            }
            if (!isExist)
            {
                Console.WriteLine("No");
            }
        }
    }
}
