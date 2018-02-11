using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RotateAndSum
{
    class RotateAndSum
    {
        static void RotateArray(int[] array)
        {
            int temp = array[array.Length-1];
            for(int i = array.Length-1; i > 0; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = temp;
        }

        static void SumArray (int [] array, int[] sumArray)
        {
            for(int i = 0; i < array.Length; i++)
            {
                sumArray[i] += array[i];
            }
        }

        static void Main(string[] args)
        {
            int[] array = Array.ConvertAll(
                           Console.ReadLine()
                           .Split(' ')
                           .Select(p => p.Trim())
                           .Where(s => !string.IsNullOrWhiteSpace(s))
                           .ToArray()
                           , p => int.Parse(p));

            int timeToRotate = int.Parse(Console.ReadLine());

            int[] sumArray = new int[array.Length];
            Array.Clear(sumArray, 0, sumArray.Length);

            for(int i = 0; i < timeToRotate; i++)
            {
                RotateArray(array);
                SumArray(array, sumArray);
            }
            foreach(int num in sumArray)
            {
                Console.Write(num + " ");
            }
        }
    }
}
