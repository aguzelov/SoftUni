using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumArrays
{
    class SumArrays
    {
        static void PrintArray(int[] firstArray, int[] secondArray)
        {
            int firstArrayLen = firstArray.Length;
            int secondArrayLen = secondArray.Length;
            
            for (int i = 0; i < Math.Max(firstArrayLen,secondArrayLen); i++)
            {
                Console.Write("{0} ", firstArray[i%firstArrayLen] + secondArray[i%secondArrayLen]);
            }
        }

        static void Main(string[] args)
        {
            int[] firstArray = Array.ConvertAll(
                                    Console.ReadLine()
                                    .Split(' ')
                                    .Select(p => p.Trim())
                                    .Where(p => !string.IsNullOrWhiteSpace(p))
                                    .ToArray() 
                              ,p => int.Parse(p));

            int[] secondArray = Array.ConvertAll(
                                    Console.ReadLine()
                                    .Split(' ')
                                    .Select(p => p.Trim())
                                    .Where(p => !string.IsNullOrWhiteSpace(p))
                                    .ToArray()
                              , p => int.Parse(p));

            PrintArray(firstArray, secondArray);
           
        }
    }
}
