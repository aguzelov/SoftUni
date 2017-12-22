using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ladybugs
{
    class Ladybugs
    {
        private static int[] field = null;

        private static void InitField()
        {
            int size = int.Parse(Console.ReadLine());

            field = new int[size];

            int[] initialArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < size; i++)
            {
                if (initialArray.Contains(i))
                {
                    field[i] = 1;
                }
                else
                {
                    field[i] = 0;
                }
            }
        }

        private static void ReadCommand(string input, out int index, out string direction, out int length)
        {
            string[] array = input.Split(' ').ToArray();

            index = int.Parse(array[0]);
            direction = array[1];
            length = int.Parse(array[2]);
        }

        private static bool ValidateIndex(int index)
        {
            if (index < 0 || index >= field.Length)
            {
                return false;
            }
            return true;
        }

        private static bool HasLadybyg(int index)
        {
            if (field[index] == 1)
            {
                return true;
            }
            return false;
        }

        private static void Right(int index, int length)
        {
            field[index] = 0;

            while (true)
            {
                index = index + length;

                if (!ValidateIndex(index))
                {
                    break;
                }

                if (HasLadybyg(index))
                {
                    continue;
                }
                else
                {
                    field[index] = 1;
                    break;
                }
            }

        }

        private static void Left(int index, int length)
        {
            field[index] = 0;

            while (true)
            {
                index = index - length;

                if (!ValidateIndex(index))
                {
                    break;
                }
                if (HasLadybyg(index))
                {
                    continue;
                }
                else
                {
                    field[index] = 1;
                    break;
                }
            }
        }

        private static bool TakeCommand()
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                Console.WriteLine(string.Join(" ", field));
                return false;
            }

            ReadCommand(input, out int index, out string direction, out int length);
            if (!ValidateIndex(index) || !HasLadybyg(index))
            {
                return true;
            }

            switch (direction)
            {
                case "right":
                    Right(index, length);
                    break;
                case "left":
                    Left(index, length);
                    break;
            }

            return true;
        }

        static void Main(string[] args)
        {
            InitField();

            while (TakeCommand()) { }

        }
    }
}
