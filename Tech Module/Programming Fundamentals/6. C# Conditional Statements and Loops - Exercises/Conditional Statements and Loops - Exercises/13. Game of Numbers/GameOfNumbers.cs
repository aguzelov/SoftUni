using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Game_of_Numbers
{
    class GameOfNumbers
    {
        static String lastCombination = null;
        static int combination;

        static void setLastCombination(string combination)
        {
            lastCombination = combination;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicalNumber = int.Parse(Console.ReadLine());

            for (int i = n; i <= m; i++)
            {
                for (int j = n; j <= m; j++)
                {
                    if ((i + j) == magicalNumber)
                    {
                        setLastCombination(i + " + " + j);
                    }
                    combination++;
                }
            }
            if (lastCombination != null)
            {
                Console.WriteLine($"Number found! {lastCombination} = {magicalNumber}");
            }
            else
            {
                Console.WriteLine($"{combination} combinations - neither equals {magicalNumber}");
            }

        }
    }
}
