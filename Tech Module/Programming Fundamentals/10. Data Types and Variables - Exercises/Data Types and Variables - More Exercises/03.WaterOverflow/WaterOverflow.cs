using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WaterOverflow
{
    class WaterOverflow
    {
        static void Main(string[] args)
        {

            int numberOfLInes = int.Parse(Console.ReadLine());

            int totalLiters = 0;

            for (int i = 0; i < numberOfLInes; ++i)
            {
                byte quantitiesToPour=0;
                try
                {
                    quantitiesToPour = byte.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                totalLiters += quantitiesToPour;
                if (totalLiters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    totalLiters -= quantitiesToPour;
                }

            }
            Console.WriteLine(totalLiters);
        }
    }
}
