using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandInterpreter
{
    class CommandInterpreter
    {
        private static List<string> list = null;

        private static void Print()
        {
            Console.WriteLine("[" + string.Join(", ", list) + "]");
        }

        private static void Reverse(int start, int count)
        {
            List<string> temp = list.GetRange(start, count);

            temp.Reverse();

            list.RemoveRange(start, count);
            list.InsertRange(start, temp);
        }

        private static void Sort(int start, int count)
        {
            List<string> temp = list.GetRange(start, count);

            temp.Sort();

            list.RemoveRange(start, count);
            list.InsertRange(start, temp);
        }

        private static void RollLeft(int count)
        {
            for (int i = 0; i < count % list.Count; i++)
            {
                list.Add(list.First());
                list.RemoveAt(0);
            }
        }

        private static void RollRight(int count)
        {
            for (int i = 0; i < count % list.Count; i++)
            {
                list.Insert(0, list.Last());
                list.RemoveAt(list.Count - 1);
            }
        }

        private static bool ValidateParameters(int start, int count)
        {
            if (start < 0 || start >= list.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return false;
            }

            if (count < 0 || start + count > list.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return false;
            }

            return true;
        }
        private static bool ValidateParameters(int count)
        {
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return false;
            }

            return true;
        }

        private static bool TakeCommand()
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                Print();
                return false;
            }

            string[] commands = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            switch (commands[0])
            {
                case "reverse":
                    int start = int.Parse(commands[2]);
                    int count = int.Parse(commands[4]);
                    if (!ValidateParameters(start, count))
                    {
                        return true;
                    }
                    Reverse(start, count);
                    break;
                case "sort":
                    start = int.Parse(commands[2]);
                    count = int.Parse(commands[4]);
                    if (!ValidateParameters(start, count))
                    {
                        return true;
                    }
                    Sort(start, count);
                    break;
                case "rollLeft":
                    count = int.Parse(commands[1]);
                    if (!ValidateParameters(count))
                    {
                        return true;
                    }
                    RollLeft(count);
                    break;
                case "rollRight":
                    count = int.Parse(commands[1]);
                    if (!ValidateParameters(count))
                    {
                        return true;
                    }
                    RollRight(count);
                    break;
            }

            return true;
        }

        static void Main(string[] args)
        {
            list = Console.ReadLine()
                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .ToList();

            while (TakeCommand()) { }

        }
    }
}
