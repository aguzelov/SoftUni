using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendLists
{
    class AppendLists
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                .Split('|')
                                .ToArray();

            Array.Reverse(input);

            List<int> list = new List<int>();

            foreach (string num in input)
            {
                string[] currentArray = num.Split(' ').Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
                for (int i = 0; i < currentArray.Length; i++)
                {
                    list.Add(int.Parse(currentArray[i]));
                }
            }

            ListMethods.PrintList<int>(list);
        }
    }
    class ListMethods
    {
        public static void PrintList<T>(List<T> list)
        {
            Console.WriteLine(string.Join(" ", list));
        }
    }

}
