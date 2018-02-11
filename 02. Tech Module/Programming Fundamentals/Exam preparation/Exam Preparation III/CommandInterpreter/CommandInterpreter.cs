using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandInterpreter
{
    class CommandInterpreter
    {
        private static List<string> collection = new List<string>();

        private static void InitCollection()
        {
            collection = Console.ReadLine()
                                         .Split(' ')
                                         .Select(p => p.Trim())
                                         .Where(p => !string.IsNullOrWhiteSpace(p))
                                         .ToList();
        }

        private static bool TakeCommand(out List<string> command)
        {
            command = null;

            string input = Console.ReadLine();
            if (input == "end")
            {
                return false;
            }

            command = input.Split(' ').ToList();

            return true;
        }

        private static void Interpreter(List<string> command)
        {
            string commandName = command[0];

            switch (commandName)
            {
                case "reverse":
                    {
                        int startIndex = int.Parse(command[2]);
                        int count = int.Parse(command[4]);
                        if (CheckForInvalidIndex(startIndex, count))
                        {
                            Reverse(startIndex, count);
                        }
                    }
                    break;
                case "sort":
                    {
                        int startIndex = int.Parse(command[2]);
                        int count = int.Parse(command[4]);
                        if (CheckForInvalidIndex(startIndex, count))
                        {
                            Sort(startIndex, count);
                        }
                    }
                    break;
                case "rollLeft":
                    {
                        int count = int.Parse(command[1]);
                        if (CheckForInvalidCount(count))
                        {
                            RollLeft(count);
                        }
                    }
                    break;
                case "rollRight":
                    {
                        int count = int.Parse(command[1]);
                        if (CheckForInvalidCount(count))
                        {
                            RollRight(count);
                        }
                    }
                    break;
            }
        }

        private static void Reverse(int startIndex, int count)
        {
            string[] partToReverse = collection.Skip(startIndex).Take(count).ToArray();

            Array.Reverse(partToReverse);

            int i = startIndex;
            while (count != 0)
            {
                collection[i] = partToReverse[i - startIndex];
                i++;
                count--;
            }
        }

        private static void Sort(int startIndex, int count)
        {
            string[] partToSort = collection.Skip(startIndex).Take(count).ToArray();

            Array.Sort(partToSort);

            int i = startIndex;

            while (count != 0)
            {
                collection[i] = partToSort[i - startIndex];
                i++;
                count--;
            }
        }

        private static void RollLeft(int count)
        {
            int rolls = count % collection.Count;

            for (int i = 0; i < rolls; i++)
            {
                string temp = collection[0];
                collection.RemoveAt(0);
                collection.Add(temp);
            }
        }

        private static void RollRight(int count)
        {
            int rolls = count % collection.Count;

            for (int i = 0; i < rolls; i++)
            {
                string temp = collection.Last();
                collection.RemoveAt(collection.Count - 1);
                collection.Insert(0, temp);
            }
        }

        private static bool CheckForInvalidIndex(int startIndex, int count)
        {
            if (startIndex < 0 ||
                startIndex >= collection.Count ||
                count < 0 ||
                startIndex + count > collection.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return false;
            }
            return true;
        }
        private static bool CheckForInvalidCount(int count)
        {
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return false;
            }
            return true;
        }

        private static void PrintCollection()
        {
            Console.WriteLine($"[{string.Join(", ", collection)}]");
        }

        static void Main(string[] args)
        {
            InitCollection();

            while (TakeCommand(out List<string> command))
            {
                Interpreter(command);
            }
            PrintCollection();
        }
    }
}
