using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ChooseADrink_2
{
    class ChooseADrink2
    {
        static Dictionary<string, string> drinks = new Dictionary<string, string>
        {
            {"Athlete", "Water"},
            {"Businessman", "Coffee" },
            {"Businesswoman", "Coffee" },
            {"SoftUni Student", "Beer" }
        };
        static Dictionary<string, double> price = new Dictionary<string, double>
        {
            {"Water", 0.70 },
            {"Coffee", 1.00 },
            {"Beer", 1.70 },
            {"Tea", 1.20 }
        };
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            try
            {

                Console.WriteLine($"The {profession} has to pay {String.Format("{0:0.00}", price[drinks[profession]] * quantity)}.");
            }
            catch (KeyNotFoundException)
            {;
                Console.WriteLine($"The {profession} has to pay {String.Format("{0:0.00}", price["Tea"] * quantity  )}.");
            }
        }
    }
}
