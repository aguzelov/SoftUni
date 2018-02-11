using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LargestCommonEnd
{
    class LargestCommonEnd
    {

        static int LargestCommonEndLeft(string[] first, string[] second)
        {
            int counter = 0;
            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                if (first[i] == second[i])
                {
                    counter++;
                }
                else
                {
                    return counter;
                }
            }
            return counter;
        }

        static int LargestCommonEndRight(string[] first, string[] second)
        {
            int firstLen = first.Length - 1;
            int secondLen = second.Length - 1;

            int counter = 0;
            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                if (first[firstLen - i] == second[secondLen - i])
                {
                    counter++;
                }

            }
            return counter;
        }

        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                                   .Split(' ')
                                   .Select(p => p.Trim())
                                   .Where(p => !string.IsNullOrWhiteSpace(p))
                                   .ToArray();

            string[] secondArray = Console.ReadLine()
                                   .Split(' ')
                                   .Select(p => p.Trim())
                                   .Where(p => !string.IsNullOrWhiteSpace(p))
                                   .ToArray();


            Console.WriteLine(Math.Max(LargestCommonEndLeft(firstArray, secondArray)
                                     , LargestCommonEndRight(firstArray, secondArray)));


        }
    }
}
