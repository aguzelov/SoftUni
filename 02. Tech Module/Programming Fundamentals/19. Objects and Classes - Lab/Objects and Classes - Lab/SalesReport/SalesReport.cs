using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReport
{
    class SalesReport
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                                        .Split(' ')
                                        .Where(p => !string.IsNullOrWhiteSpace(p))
                                        .ToArray();
                new Sale(input[0], input[1], input[2], input[3]);
            }
            Sale.PrintSalesByTown();
        }
    }
    class Sale
    {
        private string town;
        private string product;
        private double price;
        private double quantity;

        private static Dictionary<string, double> totalSaleByTown = new Dictionary<string, double> { };

        public Sale(string town, string product, string price, string quantity)
        {
            this.town = town;
            this.product = product;
            this.price = double.Parse(price);
            this.quantity = double.Parse(quantity);

            double totalSale = this.price * this.quantity;

            if (totalSaleByTown.ContainsKey(town))
            {
                totalSaleByTown[town] += totalSale;
            }
            else
            {
                totalSaleByTown.Add(town, totalSale);
            }
        }

        public string Town { get => town; set => town = value; }
        public string Product { get => product; set => product = value; }
        public double Price { get => price; set => price = value; }
        public double Quantity { get => quantity; set => quantity = value; }

        public static void PrintSalesByTown()
        {
            var sorted = totalSaleByTown.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, double> sale in sorted)
            {
                Console.WriteLine($"{sale.Key} -> {string.Format("{0:0.00}", sale.Value)}");
            }
        }
    }
}
