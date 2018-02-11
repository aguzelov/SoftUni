using System;
using System.Collections.Generic;
using System.Linq;

public class SquareWithMaximumSum
{
    public static void Main()
    {
        InitMatrix(out int[][] matrix);

        int maxSum = int.MinValue;
        int maxRow = 0;
        int maxCol = 0;
        for (int row = 0; row < matrix.Length - 1; row++)
        {
            for (int col = 0; col < matrix[row].Length - 1; col++)
            {
                int sum = CalculateSubmatrix(ref matrix, row, col);
                if (sum > maxSum)
                {
                    maxRow = row;
                    maxCol = col;
                    maxSum = sum;
                }
            }
        }
        
        PrintMatrix(ref matrix, maxRow, maxCol);
        Console.WriteLine(maxSum);
    }

    private static int CalculateSubmatrix(ref int[][] matrix, int startRow, int startCol)
    {
        int sum = 0;
        for (int row = startRow; row <= startRow + 1; row++)
        {
            for (int col = startCol; col <= startCol + 1; col++)
            {
                if (IndexOutOfRange(ref matrix, row, col))
                {
                    continue;
                }

                sum += matrix[row][col];
            }
        }
        return sum;
    }

    private static bool IndexOutOfRange(ref int[][] matrix, int row, int col)
    {
        if ((row < 0 || row >= matrix.Length) ||
            (col < 0 || col >= matrix[row].Length))
        {
            return true;
        }

        return false;
    }

    private static void InitMatrix(out int[][] matrix)
    {
        int[] matrixSize = Console.ReadLine()
            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int row = matrixSize[0];
        int col = matrixSize[1];
        matrix = new int[row][];

        for (int i = 0; i < row; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }

    private static void PrintMatrix(ref int[][] matrix, int startRow, int startCols)
    {
        for (int row = startRow; row <= startRow + 1; row++)
        {
            Console.WriteLine(matrix[row][startCols] + " " + matrix[row][startCols + 1]);
        }
    }
}
