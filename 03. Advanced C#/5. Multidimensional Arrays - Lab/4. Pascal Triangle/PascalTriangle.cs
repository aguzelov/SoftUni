using System;
using System.Collections.Generic;
using System.Linq;

public class PascalTriangle
{
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        List<List<long>> triangle = new List<List<long>>();
        
        for (int i = 0; i < rows; i++)
        {
            triangle.Add(new List<long>());
            triangle[i].Add(1);
        }

        for (int row = 1; row < rows; row++)
        {
            for (int col = 1; col < row+1; col++)
            {
                long firstNum = triangle[row - 1][col - 1];
                if (triangle[row - 1].Count <= col)
                {
                    triangle[row].Add(firstNum);
                }
                else
                {
                    long secondNum = triangle[row - 1][col];

                    triangle[row].Add(firstNum + secondNum);
                }
            }
        }

        PrintTriangle(ref triangle);
    }

    private static void PrintTriangle(ref List<List<long>> triangle)
    {
        foreach (var row in triangle)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}