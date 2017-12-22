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
            // 1 set = 6 portion = 2 bananas, 4 eggs and 0.2 kilos berries


            decimal money = decimal.Parse(Console.ReadLine());

            int guests = int.Parse(Console.ReadLine());
            decimal desertsCount = (decimal)Math.Ceiling((double)guests / 6);

            decimal bananasPrice = decimal.Parse(Console.ReadLine());
            decimal eggsPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPrice = decimal.Parse(Console.ReadLine());

            decimal cost = 0;

            cost = desertsCount * (2 * bananasPrice) + desertsCount * (4 * eggsPrice) + desertsCount * ((decimal)0.2 * berriesPrice);

            if (cost <= money)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {cost:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {cost - money:F2}lv more.");
            }
        }
    }
}
