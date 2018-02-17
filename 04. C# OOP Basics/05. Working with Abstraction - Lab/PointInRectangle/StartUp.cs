using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        Rectangle rectangle = new Rectangle(Console.ReadLine);
        int n = int.Parse(Console.ReadLine());
        while(n != 0)
        {
            int[] pointCoordinate = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(rectangle.Contains(new Point(pointCoordinate[0], pointCoordinate[1])));
            n--;
        }
    }
}