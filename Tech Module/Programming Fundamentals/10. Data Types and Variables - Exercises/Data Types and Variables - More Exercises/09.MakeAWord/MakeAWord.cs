using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.MakeAWord
{
    class MakeAWord
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string word = "";

            for(int i = 0; i < n; i++)
            {
                word += char.Parse(Console.ReadLine());
            }
            Console.WriteLine("The word is: "+word);
        }
    }
}
