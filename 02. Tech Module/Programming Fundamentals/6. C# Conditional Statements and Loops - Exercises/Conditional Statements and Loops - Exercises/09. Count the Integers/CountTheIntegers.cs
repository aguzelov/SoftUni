using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Count_the_Integers
{
    class CountTheIntegers
    {
        static void Main(string[] args)
        {
            int totalCount = 0;

            try
            {
                int input;
                while (true)
                {
                    input = int.Parse(Console.ReadLine());
                    totalCount++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(totalCount);
            }
        }
    }
}
