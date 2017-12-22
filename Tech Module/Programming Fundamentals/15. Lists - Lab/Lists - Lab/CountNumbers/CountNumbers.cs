using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumbers
{
    class CountNumbers
    {
        static Dictionary<int, int> occurrences = new Dictionary<int, int>{};
        


        static void Main(string[] args)
        {
            ListMethods.ReceiveIntList(out List<int> list, new[] { " " });
            list.Sort((a, b) => a.CompareTo(b));

            foreach(int num in list)
            {
                if (occurrences.ContainsKey(num))
                {
                    occurrences[num]+=1;
                }
                else
                {
                    occurrences.Add(num, 1);
                }
            }
            
            foreach(KeyValuePair<int, int> elem in occurrences)
            {
                Console.WriteLine(elem.Key + " -> " + elem.Value);
            }
        }
    }

    class ListMethods
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
                .Select(p => decimal.Parse(p))
                .ToList();
        }

        public static void ReceiveIntList(out List<int> list, string[] delimiters)
        {
            list = new List<int>();
            list = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.None)
                .Select(p => int.Parse(p))
                .ToList();
        }

        public static void PrintList<T>(List<T> list, string separator)
        {
            Console.WriteLine(string.Join(separator, list));
        }
    }
}
