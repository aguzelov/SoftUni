using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Word_in_Plural
{
    class WordInPlural
    {
        static void Main(string[] args)
        {
            string noun = Console.ReadLine();

            if (noun[noun.Length - 1] == 'y')
            {
                noun = noun.Replace("y", "ies");
                Console.WriteLine(noun);
            }
            else if (noun[noun.Length - 1] == 'o')
            {
                noun += "es";
                Console.WriteLine(noun);
            }
            else if (noun[noun.Length - 1] == 's')
            {
                noun += "es";
                Console.WriteLine(noun);
            }
            else if (noun[noun.Length - 1] == 'x')
            {
                noun += "es";
                Console.WriteLine(noun);
            }
            else if (noun[noun.Length - 1] == 'z')
            {
                noun += "es";
                Console.WriteLine(noun);
            }
            else if (noun.Substring(noun.Length - 2) == "ch")
            {
                noun += "es";
                Console.WriteLine(noun);
            }
            else if (noun.Substring(noun.Length - 2) == "sh")
            {
                noun += "es";
                Console.WriteLine(noun);
            }
            else
            {
                noun += "s";
                Console.WriteLine(noun);
            }
        }
    }
}
