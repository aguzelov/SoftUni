using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence
{
    class LongestIncreasingSubsequence
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(i => int.Parse(i))
                                .ToArray();

            int[] length = new int[sequence.Length];
            int[] prev = new int[sequence.Length];

            int maxLength = 0;
            int lastIndex = -1;
            
            for(int i = 0; i <sequence.Length; i++)
            {
                length[i] = 1;
                prev[i] = -1;

                for(int j = 0; j < i; j++)
                {
                    if(sequence[j] < sequence[i] && length[j] >= length[i])
                    {
                        length[i] = 1 + length[j];
                        prev[i] = j;
                    }
                }

                if(length[i] > maxLength)
                {
                    maxLength = length[i];
                    lastIndex = i;
                }
            }

            List<int> longestSequence = new List<int>();

            for(int i = 0; i < maxLength; i++)
            {
                longestSequence.Add(sequence[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSequence.Reverse();

            Console.WriteLine(string.Join(" ", longestSequence));
        }
    }
    

    public class ListMethods
    {
        public static bool CorrectIndex<T>(List<T> list, int index)
        {
            if (index < 0 || index > list.Count - 1)
            {
                return false;
            }
            return true;
        }

        public static void ReceiveStringList(out List<string> list, string[] delimiters)
        {
            list = new List<string>();
            list = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.None)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .ToList();
        }

        public static void ReceiveDecimalList(out List<decimal> list, string[] delimiters)
        {
            list = new List<decimal>();
            list = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.None)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Select(p => decimal.Parse(p))
                .ToList();
        }

        public static void ReceiveIntList(out List<int> list, string[] delimiters)
        {
            list = new List<int>();
            list = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.None)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Select(p => int.Parse(p))
                .ToList();
        }

        public static void PrintList<T>(List<T> list, string separator)
        {
            Console.WriteLine(string.Join(separator, list));
        }
    }
}
