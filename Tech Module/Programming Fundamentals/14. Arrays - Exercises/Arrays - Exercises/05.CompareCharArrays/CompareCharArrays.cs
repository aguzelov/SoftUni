using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CompareCharArrays
{
    class CompareCharArrays
    {

        static int Compare(char[] first, char[] second)
        {
            if (first == null || second == null)
            {
                Console.WriteLine("char[] = null");
            }
            int lenghtComp = first.Length.CompareTo(second.Length);
            if (lenghtComp != 0)
            {
                return lenghtComp;
            }

            return StringComparer.Ordinal.Compare(new string(first), new string(second));
        }

        static void Main(string[] args)
        {
            char[] firstArray = Array.ConvertAll(
                                Console.ReadLine()
                                .Split(' ')
                                .Select(p => p.Trim())
                                .Where(p => !string.IsNullOrWhiteSpace(p))
                                .ToArray()
                                , p => char.Parse(p));

            char[] secondArray = Array.ConvertAll(
                                Console.ReadLine()
                                .Split(' ')
                                .Select(p => p.Trim())
                                .Where(p => !string.IsNullOrWhiteSpace(p))
                                .ToArray()
                                , p => char.Parse(p));

            int result = Compare(firstArray, secondArray);

            if (result <= 0)
            {
                Console.WriteLine(new string(firstArray));
                Console.WriteLine(new string(secondArray));
            }
            else
            {
                Console.WriteLine(new string(secondArray));
                Console.WriteLine(new string(firstArray));
            }
        }
    }
}
