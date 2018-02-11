using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Training_Hall_Equipment
{
    public class Item
    {
        protected string Name { get; set; }
        protected double Price { get; set; }
        protected int Count { get; set; }

        public Item(string name, double price, int count)
        {
            this.Name = name;
            this.Price = price;
            this.Count = count;
        }

        public override string ToString()
        {
            return $"{this.Count} {(this.Count >1 ? this.Name+"s" : this.Name)}";
        }
        public double GetPrice()
        {
            return this.Price;
        }
        public double GetCount()
        {
            return this.Count;
        }
    }

    class TrainingHallEquipment
    {
        static List<Item> cart;

        static double Budget { get; set; }
        static int NumberOfItems { get; set; }

        TrainingHallEquipment(double budget, int items)
        {
            Budget = budget;
            NumberOfItems = items;
            cart = new List<Item>();
            Shoping();
        }

        static void Shoping()
        {
            while(NumberOfItems != 0)
            {
                AddToCart(new Item(Console.ReadLine(), double.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
            }
            PrintInfo();
        }

        static void AddToCart(Item item)
        {
            cart.Add(item);
            Console.WriteLine($"Adding {item.ToString()} to cart.");
            NumberOfItems--;
        }

        static double CalculateSubtotal()
        {
            double subtotal = 0;
            foreach(Item item in cart)
            {
                subtotal += item.GetPrice()*item.GetCount();
            }
            return subtotal;
        }

        static void PrintInfo()
        {
            double subtotal = CalculateSubtotal();
            if (subtotal <= Budget)
            {
                Console.WriteLine($"Subtotal: ${String.Format("{0:0.00}", subtotal)}");
                Console.WriteLine($"Money left: ${String.Format("{0:0.00}",Budget - subtotal)}");
            }
            else
            {
                Console.WriteLine($"Subtotal: ${String.Format("{0:0.00}", subtotal)}");
                Console.WriteLine($"Not enough. We need ${String.Format("{0:0.00}", subtotal-Budget)} more.");
            }
        }

        static void Main(string[] args)
        {
            new TrainingHallEquipment(double.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        }
    }
}
