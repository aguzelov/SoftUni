using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.BalancedBrackets
{
    class BalancedBrackets
    {
        
        static Queue<string> queue = new Queue<string>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            string lastBracket = "";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if(input.Equals("(") || input.Equals(")"))
                {
                    queue.Enqueue(input);

                    if(input.Equals("(") && input == lastBracket)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                    lastBracket = input;
                }
            }


            if (queue.Peek() == "(" && lastBracket == ")")
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
