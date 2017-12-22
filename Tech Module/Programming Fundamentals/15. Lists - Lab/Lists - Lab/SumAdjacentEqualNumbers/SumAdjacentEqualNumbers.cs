using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumAdjacentEqualNumbers
{
    class SumAdjacentEqualNumbers
    {
        static void Main(string[] args)
        {
            ListMethods.ReceiveIntList(out List<decimal> list);

            int index = 0;
            while(index < list.Count-1)
            {
                while(ListMethods.CorrectIndex(list, index + 1) && list[index] == list[index + 1])
                {
                    list[index] += list[index + 1];
                    list.RemoveAt(index + 1);
                    while (ListMethods.CorrectIndex(list, index - 1) && list[index - 1] == list[index])
                    {
                        index = index - 1;
                        list[index] += list[index + 1];
                        list.RemoveAt(index + 1);
                    }
                }
                index += 1;
            }
            ListMethods.PrintList(list);
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

        public static void ReceiveIntList(out List<decimal> list)
        {
            list = new List<decimal>();
            list = Console.ReadLine()
                .Split(' ')
                .Select(p => decimal.Parse(p))
                .ToList();
        }

        public static void PrintList<T>(List<T> list)
        {
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
