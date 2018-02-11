using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        private static List<int> list = null;

        private static void InitList()
        {
            list = Console.ReadLine()
                           .Split(' ')
                           .Select(int.Parse)
                           .ToList();
        }

        private static void Print()
        {
            Console.WriteLine("[" + string.Join(", ", list) + "]");
        }
        private static void Print(List<int> list)
        {
            Console.WriteLine("[" + string.Join(", ", list) + "]");
        }

        private static bool ValidateIndex(int index)
        {
            if (index < 0 || index > list.Count - 1)
            {
                Console.WriteLine("Invalid index");
                return false;
            }
            return true;
        }
        private static bool ValidateCount(int count)
        {
            if (count < 0 || count > list.Count)
            {
                Console.WriteLine("Invalid count");
                return false;
            }
            return true;
        }

        private static void Exchange(int index)
        {
            List<int> removedPart = list.GetRange(0, index + 1);
            list.RemoveRange(0, index + 1);
            list.AddRange(removedPart);
        }

        private static void Max(string oddOrEven)
        {
            int index = 0;
            if (oddOrEven == "odd")
            {
                List<int> temp = list.Where(x => x % 2 != 0).ToList();
                if (temp.Count == 0)
                {
                    Console.WriteLine("No matches");
                    return;
                }
                int maxOdd = temp.Max();
                index = list.LastIndexOf(maxOdd);
            }
            else if (oddOrEven == "even")
            {
                List<int> temp = list.Where(x => x % 2 == 0).ToList();
                if (temp.Count == 0)
                {
                    Console.WriteLine("No matches");
                    return;
                }
                int maxEven = temp.Max();
                index = list.LastIndexOf(maxEven);
            }

            Console.WriteLine(index);
        }

        private static void Min(string oddOrEven)
        {
            int index = 0;
            if (oddOrEven == "odd")
            {
                List<int> temp = list.Where(x => x % 2 != 0).ToList();
                if (temp.Count == 0)
                {
                    Console.WriteLine("No matches");
                    return;
                }
                int maxOdd = temp.Min();
                index = list.LastIndexOf(maxOdd);
            }
            else if (oddOrEven == "even")
            {
                List<int> temp = list.Where(x => x % 2 == 0).ToList();
                if (temp.Count == 0)
                {
                    Console.WriteLine("No matches");
                    return;
                }
                int maxEven = temp.Min();
                index = list.LastIndexOf(maxEven);
            }

            Console.WriteLine(index);
        }

        private static void First(int count, string evenOrOdd)
        {
            if (evenOrOdd == "odd")
            {
                List<int> temp = list.Where(x => x % 2 != 0).Take(count).ToList();
                Print(temp);
            }
            else if (evenOrOdd == "even")
            {
                List<int> temp = list.Where(x => x % 2 == 0).Take(count).ToList();
                Print(temp);
            }
        }

        private static void Last(int count, string evenOrOdd)
        {
            if (evenOrOdd == "odd")
            {
                List<int> temp = list.Where(x => x % 2 != 0).Reverse().Take(count).ToList();
                temp.Reverse();
                Print(temp);
            }
            else if (evenOrOdd == "even")
            {
                List<int> temp = list.Where(x => x % 2 == 0).Reverse().Take(count).ToList();
                temp.Reverse();
                Print(temp);
            }
        }

        private static bool TakeCommand()
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                Print();
                return false;
            }

            string[] command = input.Split(' ').ToArray();

            switch (command[0])
            {
                case "exchange":
                    int index = int.Parse(command[1]);
                    if (!ValidateIndex(index))
                    {
                        return true;
                    }
                    Exchange(index);
                    break;
                case "max":
                    string oddOrEven = command[1];
                    Max(oddOrEven);
                    break;
                case "min":
                    oddOrEven = command[1];
                    Min(oddOrEven);
                    break;
                case "first":
                    int count = int.Parse(command[1]);
                    if (!ValidateCount(count))
                    {
                        return true;
                    }
                    oddOrEven = command[2];
                    First(count, oddOrEven);
                    break;
                case "last":
                    count = int.Parse(command[1]);
                    if (!ValidateCount(count))
                    {
                        return true;
                    }
                    oddOrEven = command[2];
                    Last(count, oddOrEven);
                    break;
            }

            return true;
        }

        static void Main(string[] args)
        {
            InitList();

            while (TakeCommand()) { }
        }
    }
}
