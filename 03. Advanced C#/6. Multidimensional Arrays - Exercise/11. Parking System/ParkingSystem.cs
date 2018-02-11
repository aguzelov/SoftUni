using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingSystem
{
    private static int[] parkingDimenstion;

    private static Dictionary<int, List<int>> usedSpots = new Dictionary<int, List<int>>();

    public static void Main()
    {
        parkingDimenstion = Console.ReadLine()
           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToArray();

        while (ParkingSpotCoordinates(out int entryRow, out Position desiredSpot))
        {
            CalculateRoteLength(entryRow, desiredSpot);
        }
    }

    private static void CalculateRoteLength(int entryRow, Position desiredSpot)
    {
        int length = 1;
        int newCol = 0;
        if (usedSpots.ContainsKey(desiredSpot.Row) && usedSpots[desiredSpot.Row].Contains(desiredSpot.Col))
        {
            int bestLength = int.MaxValue;
            for (int col = 1; col < parkingDimenstion[1]; col++)
            {
                if (!(usedSpots.ContainsKey(desiredSpot.Row) && usedSpots[desiredSpot.Row].Contains(col)))
                {
                    int currentLength = Math.Abs(col - desiredSpot.Col);
                    if (currentLength < bestLength)
                    {
                        bestLength = currentLength;
                        newCol = col;

                    }
                }
            }
            desiredSpot.Col = newCol;
        }

        if (desiredSpot.Col > 0)
        {
            length += Math.Abs(entryRow - desiredSpot.Row);
            length += desiredSpot.Col;
            Console.WriteLine(length);
            SetAsUsedSpot(desiredSpot.Row, desiredSpot.Col);

        }
        else
        {
            Console.WriteLine($"Row {desiredSpot.Row} full");
        }
    }

    private static void SetAsUsedSpot(int row, int col)
    {
        if (usedSpots.ContainsKey(row))
        {
            usedSpots[row].Add(col);
        }
        else
        {
            usedSpots.Add(row, new List<int>());
            usedSpots[row].Add(col);
        }
    }

    private static bool ParkingSpotCoordinates(out int entryRow, out Position position)
    {
        entryRow = -1;
        position = null;

        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        if (input[0] == "stop")
        {
            return false;
        }

        entryRow = int.Parse(input[0]);
        int row = int.Parse(input[1]);
        int col = int.Parse(input[2]);

        position = new Position(row, col);

        return true;
    }
}

public class Position
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Position(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }
}