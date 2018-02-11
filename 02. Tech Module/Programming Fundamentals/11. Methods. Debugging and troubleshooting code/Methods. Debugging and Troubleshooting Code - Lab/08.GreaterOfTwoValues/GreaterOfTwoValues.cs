using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.GreaterOfTwoValues
{
    class GreaterOfTwoValues
    {
        static T GetMax<T>(T firstNumber, T secondNumber)
        {
            return (Comparer<T>.Default.Compare(firstNumber, secondNumber) > 0) ? firstNumber : secondNumber;
        }

        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax<int>(firstNumber, secondNumber));
            }
            else if (type == "char")
            {
                char firstNumber = char.Parse(Console.ReadLine());
                char secondNumber = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax<char>(firstNumber, secondNumber));
            }
            else if (type == "string")
            {
                string firstNumber = Console.ReadLine();
                string secondNumber = Console.ReadLine();

                Console.WriteLine(GetMax<string>(firstNumber, secondNumber));
            }
        }
    }
}
