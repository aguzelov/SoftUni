using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PairsByDifference
{
    class PairsByDifference
    {
        static int[] ReadArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        static void Main(string[] args)
        {
            int[] sequence = ReadArray();

            int difference = int.Parse(Console.ReadLine());

            List<string> pairs = new List<string>();

            for (int i = 0; i < sequence.Length; i++)
            {
                for (int j = 0; j < sequence.Length; j++)
                {
                    if (sequence[i] + difference == sequence[j])
                    {
                        pairs.Add($"{sequence[i]}, {sequence[j]}");
                    }
                }
            }

            Console.WriteLine(pairs.Count);
        }
    }
}
