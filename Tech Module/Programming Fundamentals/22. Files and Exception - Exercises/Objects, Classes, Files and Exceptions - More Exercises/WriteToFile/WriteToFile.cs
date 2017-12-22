using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteToFile
{
    class WriteToFile
    {
        static bool IsPunctuation(char c)
        {
            char[] punctuation = new char[] { '.', ',', '!', '?', ':' };

            if (Array.Exists(punctuation, x => x == c))
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\Aleksandur\Desktop\Homeworks\Objects, Classes, Files and Exceptions - More Exercises\WriteToFile\sample_text.txt";
            string text = File.ReadAllText(path);

            List<char> puctuation = new List<char>();

            foreach (char c in text)
            {
                if (!IsPunctuation(c))
                {
                    puctuation.Add(c);
                }
            }
            string output = @"C:\Users\Aleksandur\Desktop\Homeworks\Objects, Classes, Files and Exceptions - More Exercises\WriteToFile\sample_output_text.txt";
            File.WriteAllText(output, string.Join("", puctuation));
        }
    }
}
