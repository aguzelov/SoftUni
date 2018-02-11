using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelrahShake
{
    class MelrahShake
    {
        static string line;
        static string pattern;

        static bool Shake()
        {
            if (pattern.Length == 0 || !ShakeIt())
            {
                PrintLine();
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            TakeInput(out line);
            TakeInput(out pattern);

            while (Shake())
            {
            }
        }

        static bool ShakeIt()
        {
            int patternLength = pattern.Length;

            int firstIndex = line.IndexOf(pattern);
            int lastIndex = line.LastIndexOf(pattern);
            if (firstIndex < 0 && lastIndex < 0)
            {
                return false;
            }
            string currentLine = line.Remove(firstIndex, patternLength);


            lastIndex = currentLine.LastIndexOf(pattern);
            currentLine = currentLine.Remove(lastIndex, patternLength);

            line = currentLine;

            int indexToRemove = pattern.Length / 2;
            pattern = pattern.Remove(indexToRemove, 1);

            Console.WriteLine("Shaked it.");

            return true;
        }

        static void PrintLine()
        {
            Console.WriteLine("No shake.");
            Console.WriteLine(line);
        }

        static void TakeInput(out string input)
        {
            input = Console.ReadLine();
        }
    }
}
