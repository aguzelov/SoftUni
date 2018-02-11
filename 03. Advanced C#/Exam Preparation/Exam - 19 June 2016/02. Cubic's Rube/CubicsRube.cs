using System;
using System.Data;
using System.Linq;

public class CubicsRube
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int totalCels = n * n * n;

        long sum = 0;

        while (TakeLines(out int[] line))
        {
            int x = line[0];
            int y = line[1];
            int z = line[2];
            int number = line[3];

            if (IsInsideRube(n, x, y, z) && number != 0)
            {
                sum += number;
                totalCels--;
            }
        }

        Console.WriteLine(sum);
        Console.WriteLine(totalCels);
    }

    private static bool TakeLines(out int[] line)
    {
        line = null;

        string input = Console.ReadLine();
        if (input == "Analyze") return false;

        line = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        return true;
    }

    private static bool IsInsideRube(int n, int x, int y, int z)
    {
        if ((x < 0 || x >= n) ||
            (y < 0 || y >= n) ||
            (z < 0 || z >= n))
        {
            return false;
        }

        return true;
    }
}