using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToList();

            string[] commands = Console.ReadLine()
                                    .Split(' ')
                                    .ToArray();

            while (commands[0] != "Odd" && commands[0] != "Even")
            {
                if (commands[0] == "Delete")
                {
                    list.RemoveAll(p => p == int.Parse(commands[1]));
                }
                else
                {
                    list.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                }

                commands = Console.ReadLine()
                                    .Split(' ')
                                    .ToArray();
            }

            if (commands[0] == "Odd")
            {
                foreach (int num in list)
                {
                    if (num % 2 == 1)
                    {
                        Console.Write($"{num} ");
                    }
                }
            }
            else
            {
                foreach (int num in list)
                {
                    if (num % 2 == 0)
                    {
                        Console.Write($"{num} ");
                    }
                }
            }
        }
    }
}
