using System;
using System.Linq;

class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public Rectangle(Func<string> readLine)
    {
        int[] rectangleCoordinate = readLine().Split().Select(int.Parse).ToArray();
        TopLeft = new Point(rectangleCoordinate[0], rectangleCoordinate[1]);
        BottomRight = new Point(rectangleCoordinate[2], rectangleCoordinate[3]);
    }

    public bool Contains(Point point)
    {
        return (point.X >= TopLeft.X && point.X <= BottomRight.X) &&
            (point.Y >= TopLeft.Y && point.Y <= BottomRight.Y);
    }
}