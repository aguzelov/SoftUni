using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

// ReSharper disable PossibleNullReferenceException
// ReSharper disable AssignNullToNotNullAttribute

class RubiksMatrix
{
    static void Main()
    {
        var rowAndCol = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var r = rowAndCol[0];
        var c = rowAndCol[1];

        InitMatrix(out var matrix, r, c);
        InitMatrix(out var originalMatrix, r, c);


        var numberOfCommands = int.Parse(Console.ReadLine());

        while (numberOfCommands > 0)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var command = input[1];
            var rowOrColumnNumber = int.Parse(input[0]);
            var moves = int.Parse(input[2]);
            switch (command)
            {
                case "up":
                    ColumsMove(ref matrix, rowOrColumnNumber, moves, command);
                    break;
                case "down":
                    ColumsMove(ref matrix, rowOrColumnNumber, moves, command);
                    break;
                case "left":
                    RowsMove(ref matrix, rowOrColumnNumber, moves, command);
                    break;
                case "right":
                    RowsMove(ref matrix, rowOrColumnNumber, moves, command);
                    break;
            }
            numberOfCommands--;
        }

        Verification(ref originalMatrix, ref matrix);

    }

    private static void Verification(ref int[][] originalMatrix, ref int[][] matrix)
    {
        for (var row = 0; row < matrix.Length; row++)
        {
            for (var col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == originalMatrix[row][col])
                {
                    Console.WriteLine("No swap required");
                    continue;
                }

                var searchedElement = originalMatrix[row][col];
                for (var r = row; r < matrix.Length; r++)
                {
                    for (var c = 0; c < matrix[r].Length; c++)
                    {
                        if (matrix[r][c] == searchedElement)
                        {
                            matrix[r][c] = matrix[row][col];
                            matrix[row][col] = searchedElement;
                            Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                        }
                    }
                }
            }
        }
    }

    private static void RowsMove(ref int[][] matrix, int row, int moves, string command)
    {
        moves = moves % matrix[row].Length;

        if (command.Equals("left"))
        {
            for (var i = 0; i < moves; i++)
            {
                var firstElement = matrix[row][0];
                for (var col = 0; col < matrix[row].Length - 1; col++)
                {
                    matrix[row][col] = matrix[row][col + 1];
                }

                matrix[row][matrix[row].Length - 1] = firstElement;
            }
        }
        else if (command.Equals("right"))
        {
            for (var i = 0; i < moves; i++)
            {
                var lastElement = matrix[row][matrix[row].Length - 1];
                for (var col = matrix[row].Length - 1; col > 0; col--)
                {
                    matrix[row][col] = matrix[row][col - 1];
                }

                matrix[row][0] = lastElement;
            }
        }
    }

    private static void ColumsMove(ref int[][] matrix, int column, int moves, string command)
    {
        moves = moves % matrix[0].Length;

        if (command.Equals("up"))
        {
            for (var i = 0; i < moves; i++)
            {
                var firstElement = matrix[0][column];
                for (var row = 0; row < matrix.Length - 1; row++)
                {
                    matrix[row][column] = matrix[row + 1][column];
                }

                matrix[matrix.Length - 1][column] = firstElement;
            }
        }
        else if (command.Equals("down"))
        {
            for (var i = 0; i < moves; i++)
            {
                var lastElement = matrix[matrix.Length - 1][column];
                for (var row = matrix.Length - 1; row > 0; row--)
                {
                    matrix[row][column] = matrix[row - 1][column];
                }

                matrix[0][column] = lastElement;
            }
        }
    }

    public static void InitMatrix(out int[][] matrix, int r, int c)
    {
        var counter = 1;
        matrix = new int[r][];
        for (var row = 0; row < matrix.Length; row++)
        {
            matrix[row] = new int[c];
            for (var col = 0; col < matrix[row].Length; col++)
            {
                matrix[row][col] = counter++;
            }
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
