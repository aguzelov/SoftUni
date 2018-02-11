using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDessert
{
    class SweetDessert
    {
        static void Main(string[] args)
        {
            decimal amountOfCash = decimal.Parse(Console.ReadLine());

            double guests = int.Parse(Console.ReadLine());

            double bananasPrice = double.Parse(Console.ReadLine());
            double eggsPrice = double.Parse(Console.ReadLine());
            double berriesPrice = double.Parse(Console.ReadLine());

            int portions = (int)Math.Ceiling(guests / 6);

            decimal cashNeed = (decimal)(portions * (2 * bananasPrice) + portions * (4 * eggsPrice) + portions * (0.2 * berriesPrice));

            if(cashNeed <= amountOfCash)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {cashNeed:F2}lv.");
            }else if(cashNeed > amountOfCash)
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(cashNeed-amountOfCash):F2}lv more.");
            }

        }
    }
}
