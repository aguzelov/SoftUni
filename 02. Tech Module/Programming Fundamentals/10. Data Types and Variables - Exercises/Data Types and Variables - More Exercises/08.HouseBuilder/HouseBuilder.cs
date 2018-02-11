using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.HouseBuilder
{
    class HouseBuilder
    {
        static void Main(string[] args)
        {
            long intPrice = 0;
            long sbytePrice = 0;

            string price = Console.ReadLine();
            if (sbyte.TryParse(price, out sbyte sbyteValue))
            {
                sbytePrice += sbyteValue * 4;

            }else if (uint.TryParse(price, out uint intValue))
            {
                intPrice = intValue * 10L;
            }
            
            price = Console.ReadLine();
            if (sbyte.TryParse(price, out sbyteValue))
            {
                sbytePrice += sbyteValue * 4;
            }
            else if (uint.TryParse(price, out uint intValue))
            {
                intPrice += intValue * 10L;
            }
            
            Console.WriteLine(intPrice+sbytePrice);
        }
    }
}
