using System;
using System.Collections.Generic;

namespace BashSoft
{
    public static class OutputWriter
    {
        public static void PrintStudent(KeyValuePair<string, double> student)
        {
            WriteMessageOnNewLine($"{student.Key} - {student.Value}");
        }

        public static void WriteMessage(string message)
        {
            Console.Write(message);
        }

        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        public static void DisplayException(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ForegroundColor = currentColor;
        }
    }
}