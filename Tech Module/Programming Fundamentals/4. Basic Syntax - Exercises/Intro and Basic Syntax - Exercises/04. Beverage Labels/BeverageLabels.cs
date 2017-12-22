using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Beverage_Labels
{
    class BeverageLabels
    {
         string name;
        double volume;
        int energy;
        int sugar;

        BeverageLabels(string name, double volume, int energy, int sugar)
        {
            this.name = name;
            this.volume = volume;
            this.energy = energy;
            this.sugar = sugar;
        }
        void printLabel()
        {
            Console.WriteLine($"{this.volume}ml {this.name}:");
            Console.WriteLine($"{this.energy*(this.volume/100)}kcal, {this.sugar* (this.volume / 100)}g sugars");
        }
        static void Main(string[] args)
        {
            BeverageLabels label = new BeverageLabels(Console.ReadLine(), double.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            label.printLabel();
        }
    }
}
