using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToList();

            int k = input.Count / 4;

            while (input.Count > k * 2)
            {
                List<int> leftPart = input.GetRange(0, k);
                List<int> middlePart = input.GetRange(k, k * 2);
                List<int> rigthPart = input.GetRange(k * 3, input.Count - k * 3);

                leftPart.Reverse();
                rigthPart.Reverse();
                for (int i = 0; i < middlePart.Count; i++)
                {
                    if (i < k)
                    {
                        middlePart[i] += leftPart[i];
                    }
                    else
                    {
                        middlePart[i] += rigthPart[i - k];
                    }
                }
                input.Clear();
                input = middlePart;
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
