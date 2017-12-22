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
            decimal cash = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            decimal bananasPrice = decimal.Parse(Console.ReadLine());
            decimal eggsPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPrice = decimal.Parse(Console.ReadLine());

            int sets = (int)Math.Ceiling((double)guests / 6);

            decimal money = sets * (2 * bananasPrice) + sets * (4 * eggsPrice) + sets * ((decimal)0.2 * berriesPrice);

            if (money <= cash)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {money:0.00}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(money - cash):0.00}lv more.");
            }
        }
    }
}
