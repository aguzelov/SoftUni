using System;
using System.Collections.Generic;
using System.Linq;

public class JediGalaxy
{
    public static int[][] matrix;

    public static int matrixRows;
    public static int matrixCols;

    public static void Main()
    {
        InitMatrix();

        Point ivoStart = null;

        decimal sum = 0;

        while (TakeInput(ref ivoStart))
        {
            sum += GetDiagonalSum(ivoStart.Row, ivoStart.Col);
        }

        Console.WriteLine(sum);
    }

    private static decimal GetDiagonalSum(int row, int col)
    {
        decimal sum = 0;
        while (row >= 0 && col < matrixCols)
        {
            if (IsInMatrix(row, col))
            {
                int value = matrix[row][col];

                sum += value;
            }

            row--;
            col++;
        }

        return sum;
    }

    private static bool TakeInput(ref Point ivoStart)
    {
        string input = Console.ReadLine();
        if (input == "Let the Force be with you") return false;

        int[] coordinates = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        ivoStart = new Point(coordinates[0], coordinates[1]);

        coordinates = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        Point evilStart = new Point(coordinates[0], coordinates[1]);

        GetEvilPoints(evilStart.Row, evilStart.Col);

        return true;
    }

    private static void GetEvilPoints(int row, int col)
    {
        while (row >= 0 && col >= 0)
        {
            if (IsInMatrix(row, col))
            {
                matrix[row][col] = 0;
            }
            row--;
            col--;
        }
    }

    private static bool IsInMatrix(int row, int col)
    {
        if ((row < 0 || row >= matrixRows) ||
            (col < 0 || col >= matrixCols))
        {
            return false;
        }

        return true;
    }

    private static void InitMatrix()
    {
        int[] matrixSize = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        matrixRows = matrixSize[0];
        matrixCols = matrixSize[1];

        matrix = new int[matrixRows][];

        for (int row = 0; row < matrixRows; row++)
        {
            matrix[row] = new int[matrixCols];
            for (int col = 0; col < matrixCols; col++)
            {
                matrix[row][col] = row * matrixCols + col;
            }
        }
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
}