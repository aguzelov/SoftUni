using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftuniCoffeeOrders
{
    class SoftuniCoffeeOrders
    {

        static void TakeInput(out decimal price, out DateTime date, out int capsulesCount)
        {
            price = decimal.Parse(Console.ReadLine());
            date = DateTime.ParseExact(Console.ReadLine(),
                                                "d/M/yyyy",
                                                CultureInfo.InvariantCulture);
            capsulesCount = int.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Order> orders = new List<Order>();
            
            for(int i = 0; i < n; i++)
            {
                TakeInput(out decimal price, out DateTime date, out int capsulesCount);
                orders.Add(new Order(price, date, capsulesCount));
            }

            foreach(Order order in orders)
            {
                order.PrintPrice();
            }
            Order.PrintTotalPrice();
        }
    }

    class Order
    {
        private static decimal totalPrice;

        private decimal price;
        private DateTime date;
        private int capsulesCount;
        private decimal pricePerCapsule;

        public Order(decimal pricePerCapsule,DateTime date, int capsulesCount)
        {
            this.pricePerCapsule = pricePerCapsule;
            this.date = date;
            this.capsulesCount = capsulesCount;
            this.price = CalculatePrice();
            totalPrice += price;
        }

        private decimal CalculatePrice()
        {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            
            return (daysInMonth * (decimal)capsulesCount) * pricePerCapsule;
        }

        public void PrintPrice()
        {
            Console.WriteLine($"The price for the coffee is: ${this.price:F2}");
        }

        public static void PrintTotalPrice()
        {
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
