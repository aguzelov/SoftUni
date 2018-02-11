using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Exact_Sum_of_Real_Number
{
    class ExactSumOfRealNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            decimal exactSum = 0;
            for(int i = 0; i < n; i++)
            {
                exactSum += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(exactSum);
        }
    }
}
