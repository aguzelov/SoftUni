using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

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
            for (int i = 0; i < maxcount; i++)
            {
                Console.Write(maxnumbers);
                Console.Write(" ");

            }
        }
    }
}
