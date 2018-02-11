using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.JumpAround
{
    class JumpAround
    {
        static int[] array;

        static void ReadArray(out int[] array)
        {
            array = Console.ReadLine()
                        .Split(' ')
                        .Select(p => int.Parse(p))
                        .ToArray();
        }

        static void Main(string[] args)
        {
            ReadArray(out array);

            int currIdex = 0;
            int step = array[0];
            int sum = array[currIdex]; ;

            while (true)
            {
                step = array[currIdex];

                if (HasMoveRight(currIdex + step))
                {
                    currIdex = currIdex + step;
                    sum += array[currIdex];
                    step = array[currIdex];
                }
                else if (HasMoveLeft(currIdex - step))
                {
                    currIdex = currIdex - step;
                    sum += array[currIdex];
                    step = array[currIdex];
                }
                else
                {
                    Console.WriteLine(sum);
                    return;
                }
            }
        }

        static bool HasMoveRight(int index)
        {
            if (index > array.Length - 1)
            {
                return false;
            }
            return true;
        }

        static bool HasMoveLeft(int index)
        {
            if (index < 0)
            {
                return false;
            }
            return true;
        }
    }
}
