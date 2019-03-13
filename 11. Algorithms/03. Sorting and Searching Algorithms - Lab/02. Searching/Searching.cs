using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Searching
{
    internal class Searching
    {
        public static void Main()
        {
            //var items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            //var searchedItem = int.Parse(Console.ReadLine());
            var items = GenerateList();
            var searchedItem = new Random().Next(items.First(), items.Last());

            Console.Write("Items: ");
            Console.WriteLine(string.Join(" ", items));

            var index = BinarySearch<int>.Search(items, searchedItem);

            Console.Write($"Index of {searchedItem} is {index}");
        }

        private static List<int> GenerateList(int min = 0, int max = 100)
        {
            var items = new List<int>();

            for (var index = min; index < max; index++)
            {
                items.Add(index);
            }

            return items;
        }
    }
}