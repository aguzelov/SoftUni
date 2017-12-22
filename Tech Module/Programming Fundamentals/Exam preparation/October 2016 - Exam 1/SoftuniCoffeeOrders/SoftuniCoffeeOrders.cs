using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SoftuniCoffeeOrders
{
    class SoftuniCoffeeOrders
    {
        private static List<Order> orders = new List<Order>();

        private static void GetOrder()
        {
            decimal price = decimal.Parse(Console.ReadLine());
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            decimal capsulesCount = decimal.Parse(Console.ReadLine());

            orders.Add(new Order(price, date, capsulesCount));

        }

        private static void Print()
        {
            decimal totalSum = 0;
            foreach (var order in orders)
            {
                order.Print();
                totalSum += order.TotalSum;
            }
            Console.WriteLine($"Total: ${totalSum:F2}");
        }

        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < ordersCount; i++)
            {
                GetOrder();
            }

            Print();
        }
    }

    class Order
    {
        private decimal price;
        private DateTime date;
        private decimal count;
        private decimal totalSum;

        public Order(decimal price, DateTime date, decimal count)
        {
            this.price = price;
            this.date = date;
            this.count = count;
        }

        public decimal TotalSum { get => totalSum; set => totalSum = value; }

        public void Print()
        {
            this.totalSum = (DateTime.DaysInMonth(date.Year, date.Month) * this.count) * this.price;
            Console.WriteLine($"The price for the coffee is: ${this.totalSum:F2}");
        }
    }
}
