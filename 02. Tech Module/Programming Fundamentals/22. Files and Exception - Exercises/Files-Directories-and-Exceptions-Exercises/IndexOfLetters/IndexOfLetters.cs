using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IndexOfLetters
{
    class IndexOfLetters
    {
        private static readonly string inputFileName = "input.txt";
        private static readonly string outputPath = "output.txt";

        static char[] GenerateArrayOfLetters()
        {
            List<char> letters = new List<char>();

            for (char i = 'a'; i <= 'z'; i++)
            {
                letters.Add(i);
            }

            return letters.ToArray();
        }

        static void CleanOutputFile()
        {
            using (System.IO.StreamWriter writer = new StreamWriter(outputPath, false))
            {
                writer.Write(String.Empty);
            }
        }

        static void Main(string[] args)
        {
            char[] letters = GenerateArrayOfLetters();
            
            string[] lines = File.ReadAllLines(inputFileName);
            
            CleanOutputFile();

            foreach (string line in lines)
            {
                char[] inputWord = line.ToCharArray();

                using (System.IO.StreamWriter file = new StreamWriter(outputPath, true))
                {
                    for (int i = 0; i < inputWord.Length; i++)
                    {
                        file.WriteLine("{0} -> {1}", inputWord[i], Array.IndexOf(letters, inputWord[i]));
                    }
                    file.WriteLine();
                }
            }
        }
    }
}
