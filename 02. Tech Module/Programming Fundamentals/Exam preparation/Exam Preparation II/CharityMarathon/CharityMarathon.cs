using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CharityMarathon
{
    class CharityMarathon
    {
        static void PrintMoney(double money)
        {
            Console.WriteLine("Money raised: " + string.Format("{0:0.00}", money));
        }

        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int runners = int.Parse(Console.ReadLine());
            int numberOfLaps = int.Parse(Console.ReadLine());
            int lapLength = int.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());

            double moneyPerKilometer = double.Parse(Console.ReadLine());

            int totalCapacity = days * trackCapacity;

            int totalRunners = runners <= totalCapacity ? runners : totalCapacity;

            BigInteger totalMeters = BigInteger.Parse(totalRunners.ToString()) * numberOfLaps * lapLength;

            long totalKilometers = (long)(totalMeters / 1000);

            double money = totalKilometers * moneyPerKilometer;

            PrintMoney(money);

        }
    }
}