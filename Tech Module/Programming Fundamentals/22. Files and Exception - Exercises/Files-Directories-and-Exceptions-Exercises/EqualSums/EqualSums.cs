using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EqualSums
{
    internal class EqualSums
    {
        private static readonly string inputFileName = "input.txt";

        private static readonly string outputFileName = "output.txt";

        private static int SumElementsInSubarray(int[] array, int startIndex, int endIndex)
        {
            int sum = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        private static void FileWrite(string text)
        {
            using (System.IO.StreamWriter writer = new StreamWriter(outputFileName, true))
            {
                writer.WriteLine(text);
            }
        }

        private static void CleanOutputFile()
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, false))
            {
                writer.Write(String.Empty);
            }
        }

        private static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(inputFileName);

            CleanOutputFile();

            foreach (string line in lines)
            {
                int[] elements = line.Split(' ').Select(int.Parse).ToArray();

                bool isFound = false;

                for (int i = 0; i < elements.Length; i++)
                {

                    if (SumElementsInSubarray(elements, 0, i) == SumElementsInSubarray(elements, i + 1, elements.Length))
                    {
                        isFound = true;
                        FileWrite(i.ToString());
                    }
                }

                if (!isFound)
                {
                    FileWrite("no");
                }

                FileWrite(String.Empty);

            }
        }
    }
}
