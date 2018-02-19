using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int[] dimestions = GetInputAsIntArray(Console.ReadLine);

        int row = dimestions[0];
        int col = dimestions[1];

        int[,] matrix = new int[row, col];

        int value = 0;
        for (int currentRow = 0; currentRow < row; currentRow++)
        {
            for (int currentCol = 0; currentCol < col; currentCol++)
            {
                matrix[currentRow, currentCol] = value++;
            }
        }

        long sum = 0;
        while (GetCoordinates(out Coordinate ivoCoordinate, out Coordinate evilCoordinate))
        {

            while (evilCoordinate.Row >= 0 && evilCoordinate.Col >= 0)
            {
                if (IsInside(matrix, evilCoordinate))
                {
                    matrix[evilCoordinate.Row, evilCoordinate.Col] = 0;
                }
                evilCoordinate.Row--;
                evilCoordinate.Col--;
            }

            while (ivoCoordinate.Row >= 0 && ivoCoordinate.Col < matrix.GetLength(1))
            {
                if (IsInside(matrix, ivoCoordinate))
                {
                    sum += matrix[ivoCoordinate.Row, ivoCoordinate.Col];
                }

                ivoCoordinate.Col++;
                ivoCoordinate.Row--;
            }
        }

        Console.WriteLine(sum);

    }

    private static bool GetCoordinates(out Coordinate ivoCoordinate, out Coordinate evilCoordinate)
    {
        ivoCoordinate = null;
        evilCoordinate = null;

        string coordinate = Console.ReadLine();
        if (coordinate == "Let the Force be with you") return false;

        ivoCoordinate = new Coordinate(coordinate);
        evilCoordinate = new Coordinate(Console.ReadLine);

        return true;
    }

    private static bool IsInside(int[,] matrix, Coordinate coordinate)
    {
        return coordinate.Row >= 0 &&
               coordinate.Row < matrix.GetLength(0) &&
               coordinate.Col >= 0 &&
               coordinate.Col < matrix.GetLength(1);
    }

    private static int[] GetInputAsIntArray(Func<string> readCoordinates)
    {
        return readCoordinates().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    }
}