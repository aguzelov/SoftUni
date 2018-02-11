using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Cake_Ingredients
{
    class CakeIngredients
    {
        static int ingredientsCount;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while(input != "Bake!")
            {
                ingredientsCount++;
                Console.WriteLine($"Adding ingredient {input}.");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Preparing cake with {ingredientsCount} ingredients.");
        }
    }
}
