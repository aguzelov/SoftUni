using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PizzaIngredients
{
    class PizzaIngredients
    {
        static void ReadArray(out string[] array)
        {
            array = Console.ReadLine()
                            .Split(' ')
                            .ToArray();
        }

        static void Main(string[] args)
        {
            ReadArray(out string[] ingredients);

            int searchedLenght = int.Parse(Console.ReadLine());

            List<string> listOfIngredients = new List<string>();

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (i >= ingredients.Length || listOfIngredients.Count >= 10)
                {
                    Console.WriteLine($"Made pizza with total of {listOfIngredients.Count} ingredients.");
                    Console.Write($"The ingredients are: {string.Join(", ", listOfIngredients)}.");
                    Console.WriteLine();
                    return;
                }
                if (ingredients[i].Length == searchedLenght)
                {
                    listOfIngredients.Add(ingredients[i]);
                    Console.WriteLine($"Adding {ingredients[i]}.");
                }
            }
            Console.WriteLine($"Made pizza with total of {listOfIngredients.Count} ingredients.");
            Console.Write($"The ingredients are: {string.Join(", ", listOfIngredients)}.");

        }
    }
}
