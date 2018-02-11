using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace HornetAssault
{
    class HornetAssault
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine()
                                    .Split(' ')
                                    .Select(long.Parse)
                                    .ToList();

            List<long> hornets = Console.ReadLine()
                                        .Split()
                                        .Select(long.Parse)
                                        .ToList();



            long hornetPower = hornets.Sum();


            int index = 0;
            while (index != beehives.Count && hornets.Count != 0)
            {

                if (beehives[index] >= hornetPower)
                {
                    if (beehives[index] == hornetPower)
                    {
                        beehives[index] = -1;
                        hornets.RemoveAt(0);
                        hornetPower = hornets.Sum();
                    }
                    else
                    {
                        beehives[index] = beehives[index] - (int)hornetPower;
                        hornets.RemoveAt(0);
                        hornetPower = hornets.Sum();
                    }
                }
                else
                {
                    beehives[index] = -1;
                }
                index++;
            }

            beehives.RemoveAll(x => x == -1);
            if (beehives.Count != 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }
            else if (hornets.Count != 0)
            {
                Console.WriteLine(string.Join(" ", hornets));

            }
        }
    }
}
