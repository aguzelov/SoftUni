using System;
using System.Collections.Generic;
using System.Linq;

class TruckTour
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Queue<Tuple<int, int, int>> pumps = new Queue<Tuple<int,int, int>>();

        Random rnd = new Random();
        for(int i = 0; i < n; i++)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            pumps.Enqueue(new Tuple<int, int, int>(rnd.Next(1, 1000000000), input[0], input[1]));
        }


        int resultIndex = 0;
        bool solutionFound = false;
        while(true)
        {
            Tuple<int, int, int> startPump = pumps.Dequeue();
            pumps.Enqueue(startPump);

            
            long fuel = startPump.Item2;
            fuel -= startPump.Item3;

            int currentPumpCount = 1;

            while (fuel >= 0)
            {
                Tuple<int, int, int> currentPump = pumps.Dequeue();
                if(currentPump == startPump)
                {
                    solutionFound = true;
                    break;
                }

                pumps.Enqueue(currentPump);
                
                fuel += currentPump.Item2;
                fuel -= currentPump.Item3;
                currentPumpCount++;
            }
            
            if (solutionFound)
            {
                break;
            }

            resultIndex += currentPumpCount;
        }
        Console.WriteLine(resultIndex);
    }
}