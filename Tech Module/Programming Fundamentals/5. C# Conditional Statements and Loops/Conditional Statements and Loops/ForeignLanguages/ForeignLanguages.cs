using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguages
{
    class ForeignLanguages
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            switch (country)
            {
                case "USA": Console.WriteLine("English"); break;
                case "England": Console.WriteLine("English"); break;
                case "Spain": 
                case "Mexico":
                case "Argentina": Console.WriteLine("Spanish"); break;
                default: Console.WriteLine("unknown"); break;
            }
        }
    }
}
