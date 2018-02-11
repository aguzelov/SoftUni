using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus
{
    class Icarus
    {
        private static int damage = 1;
        private static int position;

        private static List<int> plane = new List<int>();
        static void Main(string[] args)
        {
            plane = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            position = int.Parse(Console.ReadLine());

            while (TakeCommand()) { }
        }

        private static bool TakeCommand()
        {
            string input = Console.ReadLine();
            if (input == "Supernova")
            {
                Print();
                return false;
            }

            string[] command = input.Split(' ').ToArray();

            switch (command[0])
            {
                case "left":
                    int steps = int.Parse(command[1]);

                    for (int i = 0; i < steps; i++)
                    {
                        position--;
                        if (position < 0)
                        {
                            position = plane.Count - 1;
                            damage++;
                        }
                        plane[position] -= damage;
                    }

                    break;
                case "right":
                    steps = int.Parse(command[1]);

                    for (int i = 0; i < steps; i++)
                    {
                        position++;
                        if (position >= plane.Count)
                        {
                            position = 0;
                            damage++;
                        }
                        plane[position] -= damage;
                    }

                    break;
            }
            return true;
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", plane));
        }

    }
}
