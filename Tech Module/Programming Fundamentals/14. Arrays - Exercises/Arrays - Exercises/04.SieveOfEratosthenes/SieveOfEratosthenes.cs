using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SieveOfEratosthenes
{
    class SieveOfEratosthenes
    {
        static void SetFlag(int[,] array, int step)
        {
            for(int i = 0; i < array.GetLength(0);i++)
            {
                int number = array[i, 0];
                if (step * number - 2 >= array.GetLength(0))
                {
                    return;
                }
                array[step*number-2, 1] = 1;
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] array = new int[n-1,2];
            int number = 2;
            for(int i = 0; i < n-1; i++)
            {
                array[i,0] = number;
                number++;
            }


            for (int i = 0; i < array.GetLength(0)-2; i++)
            {
                SetFlag(array, i+2);
            }

            for(int i = 0; i < array.GetLength(0); i++)
            {
                if(array[i,1] != 1)
                {
                    Console.Write(array[i,0] + " ");
                }
            }
        }
    }
}
