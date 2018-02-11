using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        private static List<int> array = new List<int>();

        private static void InitArray()
        {
            array = Console.ReadLine()
                           .Split(' ')
                           .Select(int.Parse)
                           .ToList();
        }

        private static bool TakeCommand()
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                PrintArray();
                return false;
            }

            string[] command = input.Split(' ').ToArray();

            switch (command[0])
            {
                case "exchange":
                    Exchange(int.Parse(command[1]));
                    break;
                case "max":
                    Max(command[1]);
                    break;
                case "min":
                    Min(command[1]);
                    break;
                case "first":
                    First(int.Parse(command[1]), command[2]);
                    break;
                case "last":
                    Last(int.Parse(command[1]), command[2]);
                    break;
            }

            return true;
        }

        private static void Exchange(int index)
        {
            if (ValidateIndex(index))
            {
                var tempRange = array.GetRange(0, index + 1);
                array.RemoveRange(0, index + 1);
                array.AddRange(tempRange);
            }
        }

        private static void Max(string parameter)
        {
            List<int> elements = new List<int>();

            if (parameter == "odd")
            {
                elements = array.Where(x => x % 2 != 0).ToList();

            }
            else if (parameter == "even")
            {
                elements = array.Where(x => x % 2 == 0).ToList();

            }

            if (elements.Count != 0)
            {
                int max = elements.Max();
                Console.WriteLine(array.LastIndexOf(max));
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        private static void Min(string parameter)
        {
            List<int> elements = new List<int>();

            if (parameter == "odd")
            {
                elements = array.Where(x => x % 2 != 0).ToList();

            }
            else if (parameter == "even")
            {
                elements = array.Where(x => x % 2 == 0).ToList();

            }

            if (elements.Count != 0)
            {
                int min = elements.Min();
                Console.WriteLine(array.LastIndexOf(min));
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        private static void First(int count, string parameter)
        {
            if (count > array.Count)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            List<int> range = null;

            if (parameter == "odd")
            {
                range = array.Where(x => x % 2 != 0).Take(count).ToList();
            }
            else if (parameter == "even")
            {
                range = array.Where(x => x % 2 == 0).Take(count).ToList();
            }


            if (range.Count == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", range) + "]");
            }

        }

        private static void Last(int count, string parameter)
        {
            if (count > array.Count)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            List<int> range = null;

            List<int> tempList = new List<int>();
            tempList.AddRange(array);
            tempList.Reverse();

            if (parameter == "odd")
            {
                range = tempList.Where(x => x % 2 != 0).Take(count).ToList();
            }
            else if (parameter == "even")
            {
                range = tempList.Where(x => x % 2 == 0).Take(count).ToList();
            }

            range.Reverse();

            if (range.Count == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", range) + "]");
            }
        }

        private static bool ValidateIndex(int index)
        {
            if (index < 0 || index >= array.Count)
            {
                Console.WriteLine("Invalid index");
                return false;
            }
            return true;
        }

        private static void PrintArray()
        {
            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }

        static void Main(string[] args)
        {
            InitArray();

            while (TakeCommand()) { }

        }

    }
}