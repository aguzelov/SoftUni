using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LastKNumbersSums
{
    class LastKNumbersSums
    {
        static List<long> sequence = new List<long>();

        static void AddToSequence(int numOfPrevious)
        {
            if(sequence.Count < numOfPrevious)
            {
                long sum = 0;
                foreach(long num in sequence)
                {
                    sum += num;
                }
                sequence.Add(sum);
            }
            else
            {
                long sum = 0;
                for(int i = sequence.Count-1; i >= sequence.Count-numOfPrevious; i--)
                {
                    sum += sequence[i];
                }
                sequence.Add(sum);
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int k = int.Parse(Console.ReadLine());

            sequence.Add(1);

            for(int i = 0; sequence.Count < n; i++)
            {
                AddToSequence(k);
            }
            foreach(long num in sequence)
            {
                Console.Write(num + " ");
            }

        }
    }
}
