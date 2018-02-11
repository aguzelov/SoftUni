using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trainegram
{
    class Trainegram
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<locomotive>\<\[[^a-zA-Z0-9]*\]\.){1}(?<wagon>(\.\[[a-zA-Z0-9]*\]\.)*?)$";

            List<string> trains = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Traincode!")
                {
                    break;
                }
                if (Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine(input);
                }
            }
        }
    }
}
