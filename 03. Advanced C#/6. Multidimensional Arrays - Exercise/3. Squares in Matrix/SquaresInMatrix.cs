using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class SquaresInMatrix
{
    public static void Main()
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var row = input[0];
        var col = input[1];

        var matrix = new string[row][];

        for (var i = 0; i < matrix.Length; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(new[] { ' ' })
                .ToArray();
        }

        int squaresCounter = 0;
        for (var i = 0; i < matrix.Length - 1; i++)
        {
            for (var j = 0; j < matrix[i].Length-1; j++)
            {
                if (CheckForSquare(ref matrix, i, j)) squaresCounter++;
            }
        }

        Console.WriteLine(squaresCounter);
    }

    public static bool CheckForSquare(ref string[][] matrix, int startRow, int startCol)
    {
        if (matrix[startRow][startCol].Equals(matrix[startRow][startCol + 1]) &&
            matrix[startRow][startCol].Equals(matrix[startRow + 1][startCol]) &&
            matrix[startRow][startCol].Equals(matrix[startRow + 1][startCol + 1]))
        {
            return true;
        }
        
        return false;
    }

    public static void PrintMatrix(ref string[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}
