using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PrimesInGivenRange
{
    class PrimesInGivenRange
    {

        static bool IsPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            List<int> primeList = new List<int>();

            for(int i = startNumber; i <= endNumber; i++)
            {
                if (IsPrime(i))
                {
                    primeList.Add(i);
                }
            }
            Console.WriteLine(String.Join(", ", primeList));
        }
    }
}
