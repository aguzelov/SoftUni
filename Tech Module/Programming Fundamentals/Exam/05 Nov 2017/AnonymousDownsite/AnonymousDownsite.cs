using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AnonymousDownsite
{
    class AnonymousDownsite
    {
        private static int securityKey;
        private static int n;
        private static decimal total = 0M;
        private static List<string> websites = new List<string>();

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            securityKey = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] inputArray = Console.ReadLine().Split(' ').Select(p => p.Trim()).ToArray();

                string name = inputArray[0];
                websites.Add(name);

                long visits = long.Parse(inputArray[1]);
                decimal price = decimal.Parse(inputArray[2]);

                total += CalLoss(visits, price);
                
            }
            Print();
        }

        private static void Print()
        {
            foreach (string name in websites)
            {
                Console.WriteLine(name);
            }
            
            Console.WriteLine($"Total Loss: {total:F20}");
            
            Console.WriteLine($"Security Token: {BigInteger.Pow(new BigInteger(securityKey), n)}");
        }
        
        private static decimal CalLoss(long visits, decimal price)
        {
            return visits * price;
        }
    }


}
