using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SafeManipulation
{
    class SafeManipulation
    {
        static void Main(string[] args)
        {
            ReadArray(out string[] array);

            //int numberOfCommands = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            while (command != "END")
            {
                StringToArray(out string[] commandArray, command);
                ExecuteCommand(commandArray, ref array);

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", array));
        }

        static void ExecuteCommand(string[] commandArray, ref string[] array)
        {
            if (commandArray[0] == "Reverse")
            {
                ReverseArray(ref array);
            }
            else if (commandArray[0] == "Distinct")
            {
                Distinct(ref array);
            }
            else if (commandArray[0] == "Replace")
            {
                Replace(ref array, int.Parse(commandArray[1]), commandArray[2]);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }

        static void ReadArray(out string[] array)
        {
            array = Console.ReadLine()
                        .Split(' ')
                        .ToArray();
        }

        static void ReverseArray(ref string[] array)
        {
            Array.Reverse(array);
        }

        static void Distinct(ref string[] array)
        {
            array = array.ToList().Distinct().ToArray();

        }

        static void Replace(ref string[] array, int index, string newWord)
        {
            if(!CheckIndexOutOfBound(index, array.Length))
            {
                return;
            }
            array[index] = newWord;
        }

        static bool CheckIndexOutOfBound(int index, int arrayLen)
        {
            if(index < 0 || index > arrayLen-1)
            {
                Console.WriteLine("Invalid input!");
                return false;
            }
            return true;
        }

        static void StringToArray(out string[] commandArray, string command)
        {
            commandArray = command.Split(' ').ToArray();
        }

    }
}
