using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Sorting
{
    public class Sorting
    {
        public static void Main()
        {
            //var array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var array = GenerateList(10);
            Console.Write("Before sorting: ");
            Console.WriteLine(string.Join(" ", array));

            array = Quicksort<int>.Sort(array);

            Console.Write("After sorting: ");
            Console.WriteLine(string.Join(" ", array));
        }

        private static List<int> GenerateList(int count, int min = 0, int max = 100)
        {
            var random = new Random();
            var items = new List<int>();

            for (var index = 0; index < count; index++)
            {
                items.Add(random.Next(min, max));
            }

            return items;
        }
    }
}