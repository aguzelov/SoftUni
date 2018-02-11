using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

// ReSharper disable AssignNullToNotNullAttribute

public class LegoBlocks
{
    public static void Main()
    {
        var rows = int.Parse(Console.ReadLine());

        var firstMatrix = new int[rows][];
        InitMatrix(ref firstMatrix);

        var secondMatrix = new int[rows][];
        InitMatrix(ref secondMatrix);

        ReverseMatrix(ref secondMatrix);
        if (IsMatched(ref firstMatrix, ref secondMatrix, out var count ))
        {
            PrintCombinedMatrix(ref firstMatrix, ref secondMatrix);
        }
        else
        {
            Console.WriteLine( $"The total number of cells is: {count}");
        }

    }

    private static void PrintCombinedMatrix(ref int[][] firstMatrix, ref int[][] secondMatrix)
    {
        var combinedColsLength = firstMatrix[0].Length + secondMatrix[0].Length;

        for (var row = 0; row < firstMatrix.Length; row++)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", firstMatrix[row]));
            Console.Write(", ");
            Console.Write(string.Join(", ", secondMatrix[row]));
            Console.WriteLine("]");
        }
    }

    private static bool IsMatched(ref int[][] firstMatrix, ref int[][] secondMatrix, out long count)
    {
        count = 0;
        SortedSet<int> rowsLength = new SortedSet<int>();

        for (var row = 0; row < firstMatrix.Length; row++)
        {
            count += firstMatrix[row].Length + secondMatrix[row].Length;
            rowsLength.Add(firstMatrix[row].Length + secondMatrix[row].Length);
        }

        return (rowsLength.Count == 1);
    }

    private static void ReverseMatrix(ref int[][] matrix)
    {
        for (var row = 0; row < matrix.Length; row++)
        {
            Array.Reverse(matrix[row]);
        }
    }

    private static void InitMatrix(ref int[][] matrix)
    {
        for (var row = 0; row < matrix.Length; row++)
        {
            var inputArray = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix[row] = inputArray;
        }
    }

    public static void PrintMatrix(ref int[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}

