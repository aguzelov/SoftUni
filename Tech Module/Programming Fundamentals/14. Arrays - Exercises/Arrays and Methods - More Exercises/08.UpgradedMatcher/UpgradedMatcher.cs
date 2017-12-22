using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.UpgradedMatcher
{
    class UpgradedMatcher
    {
        static void AddToArray(ref Product[] products, string[] names, long[] quantities, string[] prices)
        {
            for (int i = 0; i < products.Length; i++)
            {
                products[i] = new Product(names[i]
                            , ((i < quantities.Length) ? quantities[i] : 0)
                            , prices[i]);
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

            string[] input = Console.ReadLine().Split(' ').Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
            while (input[0] != "done")
            {
                Product product = SearchForProduct(products, input[0]);

                if (!product.IsEnoughQuantity(long.Parse(input[1])))
                {
                    product.PrintOutOfProducts();
                    return;
                }
                product.DecreaseQuantity(long.Parse(input[1]));
                
                input = Console.ReadLine().Split(' ').Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
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

        public void DecreaseQuantity(long quantity)
        {
            if (IsEnoughQuantity(quantity))
            {
                PrintProduct(quantity);
                this.quantities -= quantity;
            }
            else
            {
                PrintOutOfProducts();
            }
        }

        public bool IsEnoughQuantity(long quantity)
        {
            return this.quantities >= quantity;
        }

        public void PrintOutOfProducts()
        {
            Console.WriteLine($"We do not have enough {this.name}");
        }

        public void PrintProduct(long orderedQuantity)
        {
            Console.WriteLine($"{this.name} x {orderedQuantity} costs {string.Format("{0:0.00}",  (decimal)double.Parse(this.price) * orderedQuantity)}");
        }
    }
}
