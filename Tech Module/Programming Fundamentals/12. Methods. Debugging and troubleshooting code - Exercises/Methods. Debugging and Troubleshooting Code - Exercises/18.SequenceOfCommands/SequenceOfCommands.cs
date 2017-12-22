using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.SequenceOfCommands
{
    class SequenceOfCommands
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            long[] array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (!command.Equals("stop"))
            {

                int[] args = new int[2];

                string[] stringParams = command.Split(ArgumentsDelimiter);

                if (stringParams[0].Equals("add") ||
                    stringParams[0].Equals("subtract") ||
                    stringParams[0].Equals("multiply"))
                {
                    args[0] = int.Parse(stringParams[1]);
                    args[1] = int.Parse(stringParams[2]);

                    PerformAction(array, stringParams[0], args);
                }
                else
                {
                    PerformAction(array, stringParams[0], args);
                }

                PrintArray(array);

                command = Console.ReadLine();
            }
        }

        static void PerformAction(long[] array, string action, int[] args)
        {

            int pos = args[0] - 1;
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    array[pos] *= value;
                    break;
                case "add":
                    array[pos] += value;
                    break;
                case "subtract":
                    array[pos] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft(array);
                    break;
                case "rshift":
                    ArrayShiftRight(array);
                    break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            long temp = array[array.Length - 1];
            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = temp;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            long temp = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[array.Length - 1] = temp;
        }

        private static void PrintArray(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
