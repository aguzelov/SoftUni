using System;
using System.Collections.Generic;
using System.Linq;

public class SumMatrixElements
{
    public static void Main()
    {
        int[] matrixSize = Console.ReadLine()
            .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        long sum = 0;
        for (int i = 0; i < matrixSize[0]; i++)
        {
            long lineSum = Console.ReadLine()
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList().Sum();

            sum += lineSum;
        }

        Console.WriteLine(matrixSize[0]);
        Console.WriteLine(matrixSize[1]);
        Console.WriteLine(sum);
    }
}

