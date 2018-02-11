using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMon
{
    class PokeMon
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());

            int distance = int.Parse(Console.ReadLine());
            byte exhaustionFactory = byte.Parse(Console.ReadLine());

            int count = 0;
            int originalPokePower = pokePower;
            while (pokePower >= distance)
            {
                pokePower -= distance;
                count++;
                if (pokePower == originalPokePower / 2 && exhaustionFactory != 0)
                {
                    pokePower = pokePower / exhaustionFactory;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(count);
        }
    }
}
