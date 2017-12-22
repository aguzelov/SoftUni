using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine()
                          .Split(' ')
                          .Select(int.Parse)
                          .ToList();

            List<int> resultList = new List<int>();
            List<int> finalList = new List<int>();

            int counter = 1;
            int maxCounter = 1;

            resultList.Add(inputNumbers[0]);

            for (int i = 0; i < inputNumbers.Count - 1; i++)
            {
                if (inputNumbers[i] == inputNumbers[i + 1])
                {
                    counter++;
                    resultList.Add(inputNumbers[i + 1]);
                }
                else
                {
                    counter = 1;
                    resultList.Clear();
                    resultList.Add(inputNumbers[i + 1]);
                }
                if (counter > maxCounter)
                {
                    finalList.Clear();
                    maxCounter = counter;
                    finalList.AddRange(resultList);
                }

            }

            if (maxCounter == 1)
            {
                Console.WriteLine(inputNumbers[0]);
                return;
            }
            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}
