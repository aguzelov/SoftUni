using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniAirline
{
    class SoftUniAirline
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                new Flight();
            }
            Flight.TotalInfo();
        }
    }

    class Flight
    {
        private static decimal overalProfit;
        private static int counter = 0;

        private int adultCount;
        private double adultTicketPrice;

        private int youthCount;
        private double youthTicketPrice;

        private decimal fuelPricePerHour;
        private decimal fuelConsumption;

        private int flightDuration;

        private decimal income;
        private decimal expenses;

        private decimal profit;

        public Flight()
        {
            counter++;
            this.adultCount = int.Parse(Console.ReadLine());
            this.adultTicketPrice = double.Parse(Console.ReadLine());

            this.youthCount = int.Parse(Console.ReadLine());
            this.youthTicketPrice = double.Parse(Console.ReadLine());

            this.fuelPricePerHour = decimal.Parse(Console.ReadLine());
            this.fuelConsumption = decimal.Parse(Console.ReadLine());

            this.flightDuration = int.Parse(Console.ReadLine());

            CalculateIncome();
            CalculateExpenses();
            CalculateProfit();

            Print();
        }

        private void CalculateIncome()
        {
            income = (adultCount * (decimal)adultTicketPrice) + (youthCount * (decimal)youthTicketPrice);
        }

        private void CalculateExpenses()
        {
            expenses = flightDuration * fuelConsumption * fuelPricePerHour;
        }

        private void CalculateProfit()
        {
            profit = income - expenses;
            overalProfit += profit;
        }

        private void Print()
        {
            if (income >= expenses)
            {
                Console.WriteLine($"You are ahead with {profit:0.000}$.");
            }
            else
            {
                Console.WriteLine($"We've got to sell more tickets! We've lost {profit:0.000}$.");
            }
        }

        public static void TotalInfo()
        {
            Console.WriteLine($"Overall profit -> {overalProfit:0.000}$.");
            Console.WriteLine($"Average profit -> {overalProfit / counter:0.000}$.");
        }
    }
}
