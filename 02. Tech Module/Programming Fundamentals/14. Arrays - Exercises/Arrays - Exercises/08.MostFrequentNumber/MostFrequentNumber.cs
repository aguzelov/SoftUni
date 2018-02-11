using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MostFrequentNumber
{
    class MostFrequentNumber
    {

        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


            int currendNumber = 0;
            int numberCounter = 0;

            int maxNumberCounter = 0;
            int mostFrequentNumber = 0;

            for (int i = 0; i < array.Length; i++)
            {
                currendNumber = array[i];
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == currendNumber)
                    {
                        numberCounter++;
                    }
                }
                if (numberCounter > maxNumberCounter)
                {
                    maxNumberCounter = numberCounter;
                    mostFrequentNumber = currendNumber;
                    
                }
                numberCounter = 0;
            }
            Console.WriteLine(mostFrequentNumber);
        }
    }
}
