using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingSystem
{
    private static int _parkingRow;
    private static int _parkingCol;

    private static Dictionary<int, List<Point>> usedSpot = new Dictionary<int, List<Point>>();

    public static void Main()
    {
        int[] parkingParam = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        _parkingRow = parkingParam[0];
        _parkingCol = parkingParam[1];


        while (GetParams(out int entry, out int row, out int col))
        {
            int distance = Calculate(entry, row, col);
            if (distance <= 0)
            {
                Console.WriteLine($"Row {row} full");
                continue;
            }

            Console.WriteLine(distance);
        }
    }

    public static int Calculate(int entry, int row, int col)
    {
        if (!usedSpot.ContainsKey(row))
        {
            usedSpot.Add(row, new List<Point>());
        }

        if (!usedSpot[row].Contains(new Point(row, col)))
        {
            usedSpot[row].Add(new Point(row, col));
            return (Math.Abs(entry - row) + 1) + (0 + col);
        }

        int offset = 1;
        while (offset <= _parkingCol)
        {
            int left = col - offset;
            int right = col + offset;


            if (left >= 1 && !usedSpot[row].Contains(new Point(row, left)))
            {
                usedSpot[row].Add(new Point(row, left));
                return (Math.Abs(entry - row) + 1) + (0 + left);
            }


            if (right < _parkingCol && !usedSpot[row].Contains(new Point(row, right)))
            {
                usedSpot[row].Add(new Point(row, right));
                return (Math.Abs(entry - row) + 1) + (0 + right);
            }

            offset++;
        }

        return -1;
    }

    public static bool GetParams(out int entry, out int row, out int col)
    {
        entry = -1;
        row = -1;
        col = -1;

        string input = Console.ReadLine();

        if (input == "stop") return false;

        int[] parkingStopParams = input
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        entry = parkingStopParams[0];
        row = parkingStopParams[1];
        col = parkingStopParams[2];

        return true;
    }
}

public class Point
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Point(int row, int col)
    {
        Row = row;
        Col = col;
    }

    private bool Equals(Point other)
    {
        return this.Row == other.Row && this.Col == other.Col;
    }

    public override bool Equals(object obj)
    {
        var item = obj as Point;
        if (item == null) return false;

        return this.Equals(item);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
