using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladybugs
{
    class Ladybugs
    {
        static int[] field = null;

        static void SetLadybygs()
        {
            int[] ladybugsIndex = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            foreach (int index in ladybugsIndex)
            {
                if (ValidateIndex(index))
                {
                    field[index] = 1;
                }
            }
        }

        static bool ValidateIndex(int index)
        {
            return index >= 0 && index < field.Length;
        }

        static bool TakeCommand()
        {
            string input = Console.ReadLine();

            if (input == "end")
            {
                PrintField();

                return false;
            }

            string[] command = input.Split(' ').Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();

            int index = int.Parse(command[0]);
            string direction = command[1];
            int flyLength = int.Parse(command[2]);

            if (!ValidateIndex(index) || field[index] == 0)
            {
                return true;
            }

            Fly(index, direction, flyLength);

            return true;
        }

        static void Fly(int index, string direction, int length)
        {
            field[index] = 0;
            if (direction == "right")
            {
                int newIndex = index + length;
                while (ValidateIndex(newIndex))
                {
                    if (field[newIndex] == 1)
                    {
                        newIndex = newIndex + length;
                    }
                    else
                    {
                        field[newIndex] = 1;
                        return;
                    }
                }
            }
            else
            {
                int newIndex = index - length;
                while (ValidateIndex(newIndex))
                {
                    if (field[newIndex] == 1)
                    {
                        newIndex = newIndex - length;
                    }
                    else
                    {
                        field[newIndex] = 1;
                        return;
                    }
                }
            }
        }

        static void PrintField()
        {
            Console.WriteLine(string.Join(" ", field));
        }

        static void Main(string[] args)
        {
            field = new int[int.Parse(Console.ReadLine())];

            SetLadybygs();

            while (TakeCommand())
            {

            }

        }
    }
}
