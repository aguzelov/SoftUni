using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.DecryptingMessage
{
    class DecryptingMessage
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string message = "";

            for (int i = 0; i < n; i++)
            {
                message += (char)(char.Parse(Console.ReadLine()) + key);
            }
            Console.WriteLine(message);
        }
    }
}
