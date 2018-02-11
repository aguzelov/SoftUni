using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable PossibleNullReferenceException

public class DiagonalDifference
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var matrix = new long[n][];

        for (var row = 0; row < matrix.Length; row++)
        {
            matrix[row] = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

        }

        var primarySum = 0L;
        var secondarySum = 0L;

        for (var i = 0; i < matrix.Length; i++)
        {
            primarySum += matrix[i][i];
            secondarySum += matrix[i][matrix.Length - 1 - i];
        }

        Console.WriteLine(Math.Abs(primarySum - secondarySum));


    }

    public static void PrintMatrix(int[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}

