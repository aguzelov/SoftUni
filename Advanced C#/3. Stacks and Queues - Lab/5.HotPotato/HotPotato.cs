using System;
using System.Collections.Generic;
using System.Linq;

class HotPotato
{
    static void Main()
    {
        string[] kidsName = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        int n = int.Parse(Console.ReadLine());

        Queue<string> kids = new Queue<string>(kidsName);

        int counter = 0;

        while(kids.Count != 1)
        {

            string currentKid = kids.Dequeue();
            counter++;
            if(counter == n)
            {
                Console.WriteLine($"Removed {currentKid}");
                counter = 0;
            }
            else
            {
                kids.Enqueue(currentKid);
            }
        }

        Console.WriteLine($"Last is {kids.Peek()}");
    }
}

