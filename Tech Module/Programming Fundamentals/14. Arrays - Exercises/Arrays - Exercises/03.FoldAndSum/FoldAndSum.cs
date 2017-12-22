using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FoldAndSum
{
    class FoldAndSum
    {

        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void SumArrays(int[] first, int[] second)
        {
            for (int i = 0; i < first.Length; i++)
            {
                first[i] += second[i];
            }
        }

        static void Main(string[] args)
        {
            int[] array = Array.ConvertAll(
                          Console.ReadLine()
                          .Split(' ')
                          .Select(p => p.Trim())
                          .Where(p => !string.IsNullOrWhiteSpace(p))
                          .ToArray()
                          , p => int.Parse(p));

            int k = array.Length / 4;


            //left part - select and rotate
            int[] leftArray = new int[k];
            for (int i = 0; i < k; i++)
            {
                leftArray[i] = array[i];
            }
            Array.Reverse(leftArray);

            // right part - select and rotate
            int[] rightArray = new int[k];
            for (int i = 0; i < k; i++)
            {
                rightArray[i] = array[i + (k * 3)];
            }
            Array.Reverse(rightArray);

            int[] rotatedArray = new int[leftArray.Length + rightArray.Length];
            leftArray.CopyTo(rotatedArray, 0);
            rightArray.CopyTo(rotatedArray, leftArray.Length);

            //middle part
            int[] middleArray = new int[k * 2];
            for (int i = 0; i < middleArray.Length; i++)
            {
                middleArray[i] = array[i + k];
            }

            SumArrays(middleArray, rotatedArray);
            PrintArray(middleArray);
        }
    }
}
