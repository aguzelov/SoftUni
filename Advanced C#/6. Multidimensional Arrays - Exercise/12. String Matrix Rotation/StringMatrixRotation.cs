using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StringMatrixRotation
{
    private static List<List<char>> matrix = new List<List<char>>();

    private static int maxCol;

    public static void Main()
    {
        int degrees = GetDegrees();
        maxCol = int.MinValue;

        while (TakeLine(out List<char> line))
        {
            matrix.Add(line);
            if (line.Count > maxCol)
            {
                maxCol = line.Count;
            }
        }
        
        for (int count = 1; count <= (degrees / 90) % 4; count++)
        {
            Rotate(ref matrix);
        }

        PrintMatrix(ref matrix);
    }

    private static void Rotate(ref List<List<char>> matrix)
    {

        List<List<char>> newMatrix = new List<List<char>>();
        for (int col = 0; col < maxCol; col++)
        {
            List<char> line = new List<char>();
            for (int row = matrix.Count - 1; row >= 0; row--)
            {
                if ((row < 0 || row > matrix.Count - 1) ||
                    (col < 0 || col > matrix[row].Count - 1))
                {
                    line.Add(' ');
                }
                else
                {
                    line.Add(matrix[row][col]);
                }
            }

            if (line.Count != 0)
            {
                newMatrix.Add(line);
            }

            if (line.Count > maxCol)
            {
                maxCol = line.Count;
            }
        }

        matrix.Clear();
        matrix = newMatrix;
    }

    private static void PrintMatrix(ref List<List<char>> matrix)
    {
        foreach (var row in matrix)
        {
            if (row.Count == 0)
            {
                continue;
            }
            Console.WriteLine(string.Join("", row));
        }
    }

    private static bool TakeLine(out List<char> line)
    {
        line = null;

        string input = Console.ReadLine();
        if (input == "END")
        {
            return false;
        }

        line = new List<char>(input.ToCharArray());
        return true;
    }

    private static int GetDegrees()
    {
        string input = Console.ReadLine();

        Regex regex = new Regex(@"\w+\(([0-9]+)\)");

        Match match = regex.Match(input);
        int degrees = int.Parse(match.Groups[1].Value);

        return degrees;
    }
}
