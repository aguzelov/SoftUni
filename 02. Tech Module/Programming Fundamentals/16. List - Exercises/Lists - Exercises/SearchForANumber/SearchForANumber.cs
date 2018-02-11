using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SearchForANumber
{
    class SearchForANumber
    {

        static void TakeFromTheList(ref List<int> list, int index)
        {
            if (ListMethods.CorrectIndex(list, index))
            {
                list.RemoveRange(index, list.Count - index);
            }
        }

        static void DeleteFromList(ref List<int> list, int index)
        {
            if (ListMethods.CorrectIndex(list, index - 1))
            {

                list.RemoveRange(0,index);
            }
        }

        static void SearchInListForNumber(ref List<int> list, int number)
        {
            foreach (int num in list)
            {
                if (num == number)
                {
                    Console.WriteLine("YES!");
                    return;
                }
            }

            Console.WriteLine("NO!");
        }

        static void Main(string[] args)
        {
            // recieve List<int> from console
            ListMethods.ReceiveIntList(out List<int> list, new[] { " " });


            // [0] - number of elements to take from the list (starting from the first one)
            // [1] - number of elements to delete from list (starting from the first one)
            // [2] - number searched in collection
            int[] numbers = Console.ReadLine()
                                .Split(' ')
                                .Where(p => !string.IsNullOrEmpty(p))
                                .Select(p => int.Parse(p))
                                .ToArray();


            TakeFromTheList(ref list, numbers[0]);

            DeleteFromList(ref list, numbers[1]);

            SearchInListForNumber(ref list, numbers[2]);
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
