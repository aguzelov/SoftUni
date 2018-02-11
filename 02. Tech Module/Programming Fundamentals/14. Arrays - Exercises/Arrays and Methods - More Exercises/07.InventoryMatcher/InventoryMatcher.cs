using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.InventoryMatcher
{
    class InventoryMatcher
    {
        static void AddToArray(ref Product[] products, string[] names, long[] quantities, string[] prices)
        {
            for (int i = 0; i < products.Length; i++)
            {
                products[i] = new Product(names[i], quantities[i], prices[i]);
            }
        }

        static Product SearchForProduct(Product[] products, string name)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Name == name)
                {

                    return products[i];
                }
            }
            return new Product();
        }

        static void Main(string[] args)
        {
            string[] productNames = Console.ReadLine().Split(' ').Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();

            long[] productQuantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            string[] productPrices = Console.ReadLine().Split(' ').Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();

            Product[] products = new Product[productNames.Length];
            AddToArray(ref products, productNames, productQuantities, productPrices);

            string nameOfProduct = Console.ReadLine();
            while (nameOfProduct != "done")
            {
                SearchForProduct(products, nameOfProduct).PrintProduct();

                nameOfProduct = Console.ReadLine();
            }
        }
    }

    class Product
    {
        string name;
        long quantities;
        string price;

        public Product()
        {
            this.Name = "";
            this.Quantities = 0;
            this.Price = "";
        }

        public Product(string name, long quantities, string price)
        {
            this.Name = name;
            this.Quantities = quantities;
            this.Price = price;
        }

        public string Name { get => name; set => name = value; }
        public long Quantities { get => quantities; set => quantities = value; }
        public string Price { get => price; set => price = value; }

        public bool Equals(string name)
        {
            return this.Name == name;
        }

        public void PrintProduct()
        {
            Console.WriteLine($"{this.name} costs: {this.price}; Available quantity: {this.quantities}");
        }
    }
}
