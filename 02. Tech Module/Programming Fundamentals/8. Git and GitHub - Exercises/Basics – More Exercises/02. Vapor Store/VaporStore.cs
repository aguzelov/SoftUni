using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Vapor_Store
{
    class VaporStore
    {
        static double balance;
        static double startBalance;

        VaporStore(double balance)
        {
            VaporStore.balance = balance;
            VaporStore.startBalance = balance;
        }

        static Dictionary<string, double> priceTable = new Dictionary<string, double>
        {
            {"OutFall 4", 39.99 },
            {"CS: OG", 15.99 },
            {"Zplinter Zell", 19.99 },
            {"Honored 2", 59.99 },
            {"RoverWatch", 29.99 },
            {"RoverWatch Origins Edition", 39.99 }
        };
        static void Main(string[] args)
        {
            VaporStore store = new VaporStore(double.Parse(Console.ReadLine()));
            string userInput = Console.ReadLine();

            while (userInput != "Game Time")
            {


                if (priceTable.TryGetValue(userInput, out double price))
                {
                    if (price > balance)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        Console.WriteLine($"Bought {userInput}");
                        balance -= price;
                    }

                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                userInput = Console.ReadLine();

            }
            Console.WriteLine($"Total spent: ${String.Format("{0:0.00}", startBalance - balance)}. Remaining: ${String.Format("{0:0.00}", balance)}");
        }
    }
}
