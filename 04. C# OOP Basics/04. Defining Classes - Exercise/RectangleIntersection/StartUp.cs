using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        int[] rectangleParam = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int numberOfRectangle = rectangleParam[0];
        int numberOfIntersection = rectangleParam[1];

        Dictionary<string, Rectangle> rectangles = new Dictionary<string, Rectangle>();

        for (int i = 0; i < numberOfRectangle; i++)
        {
            string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string id = inputArray[0];
            double width = double.Parse(inputArray[1]);
            double height = double.Parse(inputArray[2]);
            double topLeftX = double.Parse(inputArray[3]);
            double topLeftY = double.Parse(inputArray[4]);
            
            rectangles.Add(id ,new Rectangle(id, width, height, new Point(topLeftX, topLeftY)));
        }

        for (int i = 0; i < numberOfIntersection; i++)
        {
            string[] pair = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstId = pair[0];
            string secondId = pair[1];
            if (rectangles.ContainsKey(firstId))
            {
                Rectangle first = rectangles[firstId];
                if (rectangles.ContainsKey(secondId))
                {
                    Rectangle second = rectangles[secondId];
                    Console.WriteLine(first.IsIntersectWith(second).ToString().ToLower());
                }
            }
        }
    }
}