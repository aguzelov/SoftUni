using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                                        .Split(' ')
                                        .Where(p => !string.IsNullOrWhiteSpace(p))
                                        .ToList();
            Random rnd = new Random();
            
            for(int i = 0; i < rnd.Next(); i++)
            {
                input.Add(input[0]);
                input.RemoveAt(0);
            }

            foreach(string word in input)
            {
                Console.WriteLine(word);
            }

        }
    }
}
