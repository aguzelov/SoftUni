using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaxSequenceOfEquaElements
{
    class MaxSequenceOfEquaElements
    {
        static string[] ReadFile()
        {
            string[] lines = File.ReadAllLines("input.txt");
            return lines;
        }

        static void WriteToFile(string text)
        {
            using (StreamWriter writer = new StreamWriter("output.txt", true))
            {
                writer.WriteLine(text);
            }
        }

        static void CleanOutputFile()
        {
            using (StreamWriter writer = new StreamWriter("output.txt", false))
            {
                writer.Write(String.Empty);
            }
        }

        static void Main(string[] args)
        {
            CleanOutputFile();

            string[] lines = ReadFile();

            foreach (string line in lines)
            {
                List<int> numbers = line.Split(' ').Select(int.Parse).ToList();

                int maxnumbers = 0;
                int count = 1;

                int maxcount = 1;
                int pos = 0;

                while (pos < numbers.Count - 1)
                {

                    if (numbers[pos] == numbers[pos + 1])
                    {
                        count++;

                        if (count > maxcount)
                        {
                            maxcount = count;
                            maxnumbers = numbers[pos];
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                    pos++;
                    if (maxcount == 1)
                    {
                        maxnumbers = numbers[0];
                    }
                }
                List<int> number = new List<int>();

                for (int i = 0; i < maxcount; i++)
                {
                    number.Add(maxnumbers);
                }
                WriteToFile(string.Join(" ", number));
                WriteToFile(String.Empty);
            }
        }
    }
}
