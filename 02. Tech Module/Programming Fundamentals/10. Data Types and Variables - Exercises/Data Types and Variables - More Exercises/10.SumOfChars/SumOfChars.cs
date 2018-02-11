using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SumOfChars
{
    class SumOfChars
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for(int i = 0; i< n; i++)
            {
                sum += (int)char.Parse(Console.ReadLine());
            }
            Console.WriteLine("The sum equals: "+sum);
        }
    }
}
