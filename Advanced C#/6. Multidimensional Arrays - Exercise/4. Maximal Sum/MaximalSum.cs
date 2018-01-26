using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable PossibleNullReferenceException

public class MaximalSum
{
    public static void Main()
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var n = input[0];
        var m = input[1];

        var matrix = new int[n][];
        for (var row = 0; row < matrix.Length; row++)
        {
            matrix[row] = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }


        var maxSum = long.MinValue;
        var startRowMaxSumSquare = -1;
        var startColMaxSumSquare = -1;
        for (var row = 0; row < matrix.Length - 2; row++)
        {
            for (var col = 0; col < matrix[row].Length - 2; col++)
            {
                var currentSquareSum = CalculateSumOfCurrentSquare(ref matrix, row, col);
                if (maxSum < currentSquareSum)
                {
                    maxSum = currentSquareSum;
                    startRowMaxSumSquare = row;
                    startColMaxSumSquare = col;
                }

            }
        }



        Console.WriteLine($"Sum = {maxSum}");

        for (var row = startRowMaxSumSquare; row < startRowMaxSumSquare + 3; row++)
        {
            for (var col = startColMaxSumSquare; col < startColMaxSumSquare + 3; col++)
            {
                Console.Write(matrix[row][col] + " ");
            }
            Console.WriteLine();
        }
    }

    public static long CalculateSumOfCurrentSquare(ref int[][] matrix, int startRow, int startCol)
    {
        var sum = 0L;

        for (var row = startRow; row < startRow + 3; row++)
        {
            for (var col = startCol; col < startCol + 3; col++)
            {
                sum += matrix[row][col];
            }
        }

        return sum;
    }
}



