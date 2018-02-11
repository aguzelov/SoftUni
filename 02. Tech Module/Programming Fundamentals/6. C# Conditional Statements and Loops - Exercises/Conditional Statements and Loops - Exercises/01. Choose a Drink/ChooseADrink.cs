using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Choose_a_Drink
{
    class ChooseADrink
    {
        static Dictionary<string, string> drinks = new Dictionary<string, string>
        {
            {"Athlete", "Water"},
            {"Businessman", "Coffee" },
            {"Businesswoman", "Coffee" },
            {"SoftUni Student", "Beer" }
        };

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(drinks[Console.ReadLine()]);
            }
            catch (KeyNotFoundException exc)
            {
                Console.WriteLine("Tea");
            }
        }
    }
}
