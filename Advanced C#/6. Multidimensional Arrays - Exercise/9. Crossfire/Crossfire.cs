using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

public class Crossfire
{
    public static void Main()
    {
        InitMatrix(out var matrix);

        TargetDetails target = null;
        while (TakeInput(ref target))
        {
            Strike(ref matrix, ref target);
        }

        PrintMatrix(ref matrix);
    }

    private static void Strike(ref List<List<long>> matrix, ref TargetDetails target)
    {
        for (var row = target.Row - target.Radius; row <= target.Row + target.Radius; row++)
        {
            if (row < 0 || row >= matrix.Count)
            {
                continue;
            }

            if (row == target.Row)
            {
                for (var col = target.Col + target.Radius; col >= target.Col - target.Radius; col--)
                {
                    if (col < 0 || col >= matrix[row].Count)
                    {
                        continue;
                    }
                    matrix[row].RemoveAt(col);
                }
            }
            else
            {
                if (target.Col < 0 || target.Col >= matrix[row].Count)
                {
                    continue;
                }
                matrix[row].RemoveAt(target.Col);
            }
        }

        for (int row = 0; row < matrix.Count; row++)
        {
            if (matrix[row].Count == 0)
            {
                matrix.RemoveAt(row);
                row--;
            }
        }
    }

    private static bool TakeInput(ref TargetDetails target)
    {
        var input = Console.ReadLine();
        if (input == "Nuke it from orbit")
        {
            return false;
        }

        var targetAndRadius = input
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int targetRow = targetAndRadius[0];
        int targetCol = targetAndRadius[1];
        int radius = targetAndRadius[2];

        target = new TargetDetails(targetRow, targetCol, radius);
        return true;
    }

    public static void InitMatrix(out List<List<long>> matrix)
    {
        // ReSharper disable once PossibleNullReferenceException
        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var r = input[0];
        var c = input[1];

        matrix = new List<List<long>>();

        var counter = 1;
        for (int row = 0; row < r; row++)
        {
            matrix.Add(new List<long>());
            for (var col = 0; col < c; col++)
            {
                matrix[row].Add(counter++);
            }
        }
    }

    public static void PrintMatrix(ref List<List<long>> matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}

public class TargetDetails
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Radius { get; set; }

    public TargetDetails()
    {

    }

    public TargetDetails(int row, int col, int radius)
    {
        Row = row;
        Col = col;
        Radius = radius;
    }
}

