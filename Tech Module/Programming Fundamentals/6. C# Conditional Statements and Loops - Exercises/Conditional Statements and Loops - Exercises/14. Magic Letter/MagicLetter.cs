using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Magic_Letter
{
    class MagicLetter
    {
        static void Main(string[] args)
        {
            char firstLetter =char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());

            char thirdLetter = char.Parse(Console.ReadLine());

            for(char i = firstLetter; i <= secondLetter; i++)
            {
                for(char j = firstLetter; j <= secondLetter; j++)
                {
                    for(char l = firstLetter; l <= secondLetter; l++)
                    {
                        if (!(i.ToString() + j.ToString() + l.ToString()).Contains(thirdLetter))
                        {
                            Console.Write(i.ToString()+j+l+" ");
                        }
                    }
                }
            }
        }
    }
}
