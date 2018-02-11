using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayModifier
{
    class ArrayModifier
    {
        private static List<long> array = new List<long>();

        private static void InitArray()
        {
            array = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(", ", array));
        }

        private static bool ValidateIndex(int index)
        {
            if (index < 0 || index >= array.Count)
            {
                return false;
            }
            return true;
        }

        private static void Swap(int firstIndex, int secondIndex)
        {
            if (ValidateIndex(firstIndex) && ValidateIndex(secondIndex))
            {
                long temp = array[firstIndex];
                array[firstIndex] = array[secondIndex];
                array[secondIndex] = temp;
            }
        }

        private static void Multiply(int firstIndex, int secondIndex)
        {
            if (ValidateIndex(firstIndex) && ValidateIndex(secondIndex))
            {
                array[firstIndex] = array[firstIndex] * array[secondIndex];
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
                case "swap":
                    int first = int.Parse(command[1]);
                    int second = int.Parse(command[2]);
                    Swap(first, second);
                    break;
                case "multiply":
                    first = int.Parse(command[1]);
                    second = int.Parse(command[2]);
                    Multiply(first, second);
                    break;
                case "decrease":
                    array = array.Select(i => i - 1).ToList();
                    break;
            }

            return true;
        }

        static void Main(string[] args)
        {
            InitArray();

            while (TakeCommand()) { }

        }
    }
}
