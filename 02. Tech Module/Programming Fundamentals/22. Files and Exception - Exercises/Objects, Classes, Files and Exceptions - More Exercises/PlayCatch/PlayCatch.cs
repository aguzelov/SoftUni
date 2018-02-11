using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayCatch
{
    class PlayCatch
    {

        static long[] array = null;
        static int exceptionCounter = 0;

        static bool GetCommand()
        {
            if (exceptionCounter >= 3)
            {
                Console.WriteLine(string.Join(", ", array));
                return false;
            }

            string[] input = Console.ReadLine()
                           .Split(' ')
                           .ToArray();

            string command = input[0];

            switch (command)
            {
                case "Replace":
                    if (IndexValidation(input, "1") &&
                        ValueValidation(input[1]) &&
                        IndexValidation(input, "2") &&
                        ValueValidation(input[2]))
                    {
                        string index = input[1];
                        string element = input[2];
                        Replace(index, element);
                    }
                    break;
                case "Print":
                    if (IndexValidation(input, "1") &&
                        ValueValidation(input[1]) &&
                        IndexValidation(input, "2") &&
                        ValueValidation(input[2]))
                    {
                        string startIndex = input[1];
                        string endIndex = input[2];
                        Print(startIndex, endIndex);
                    }
                    break;
                case "Show":
                    if (IndexValidation(input, "1"))
                    {
                        string showIndex = input[1];
                        Show(showIndex);
                    }
                    break;
            }
            return true;
        }

        static void Replace(string index, string element)
        {
            if (IndexValidation(array, index) && ValueValidation(element))
            {
                int intIndex = int.Parse(index);

                array[intIndex] = int.Parse(element);
            }
        }

        static void Print(string startIndex, string endIndex)
        {
            if (ValueValidation(startIndex) && ValueValidation(endIndex))
            {
                if (IndexValidation(array, startIndex) && IndexValidation(array, endIndex))
                {
                    int start = int.Parse(startIndex);
                    int end = int.Parse(endIndex);

                    for (int i = start; i <= end; i++)
                    {
                        if (i == end)
                        {
                            Console.WriteLine(array[i]);
                        }
                        else
                        {
                            Console.Write(array[i] + ", ");
                        }
                    }
                }
            }
        }

        static void Show(string index)
        {
            if (ValueValidation(index) && IndexValidation(array, index))
            {
                int intIndex = int.Parse(index);
                Console.WriteLine(array[intIndex]);
            }
        }

        static bool IndexValidation<T>(T[] array, string index)
        {

            try
            {
                int intIndex = int.Parse(index);

                var someElement = array[intIndex];

                return true;
            }
            catch
            {
                exceptionCounter++;
                Console.WriteLine("The index does not exist!");
                return false;
            }

        }

        static bool ValueValidation(string value)
        {
            try
            {
                int.Parse(value);
                return true;
            }
            catch
            {
                exceptionCounter++;
                Console.WriteLine("The variable is not in the correct format!");
                return false;
            }
        }

        static void Main(string[] args)
        {

            array = Console.ReadLine()
                        .Split(' ')
                        .Select(long.Parse)
                        .ToArray();



            while (GetCommand()) { }
        }
    }
}
