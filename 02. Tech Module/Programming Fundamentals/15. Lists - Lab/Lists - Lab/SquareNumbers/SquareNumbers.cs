using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareNumbers
{
    class SquareNumbers
    {
        static void Main(string[] args)
        {
            ListMethods.ReceiveLongList(out List<long> list,new[] {" "});
            
            list.Sort((a, b) => b.CompareTo(a));

            List<long> extractList = new List<long>();

            foreach(var num in list)
            {
                if(Math.Sqrt(num) == (int)Math.Sqrt(num))
                {
                    extractList.Add(num);
                }
            }

            ListMethods.PrintList<long>(extractList, " ");

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

        public static void ReceiveLongList(out List<long> list, string[] delimiters)
        {
            list = new List<long>();
            list = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.None)
                .Select(p => long.Parse(p))
                .ToList();
        }

        public static void PrintList<T>(List<T> list, string separator)
        {
            Console.WriteLine(string.Join(separator, list));
        }
    }
}
