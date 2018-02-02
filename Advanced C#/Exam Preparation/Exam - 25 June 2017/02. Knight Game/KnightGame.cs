
using System;
using System.ComponentModel.Design;

public class KnightGame
{
    private static char[][] board;
    public static void Main()
    {
        InitBoard();

        int count = 0;
        while (HasAttackedKnight())
        {
            count++;
        }

        Console.WriteLine(count);
    }

    private static bool HasAttackedKnight()
    {
        int maxEnemyCount = int.MinValue;
        int maxRow = -1;
        int maxCol = -1;
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                int currenEnemyCount = 0;
                if (board[row][col] == '0')
                {
                    continue;
                }

                currenEnemyCount = CalculateEnemyKnight(row, col);
                if (currenEnemyCount > maxEnemyCount)
                {
                    maxEnemyCount = currenEnemyCount;
                    maxRow = row;
                    maxCol = col;
                }
            }
        }

        if (maxEnemyCount > 0)
        {
            board[maxRow][maxCol] = '0';
            return true;
        }

        return false;
    }

    private static int CalculateEnemyKnight(int row, int col)
    {
        int enemy = 0;

        if (HasEnemy(row - 1, col - 2)) enemy++;
        if (HasEnemy(row - 2, col - 1)) enemy++;

        if (HasEnemy(row - 2, col + 1)) enemy++;
        if (HasEnemy(row - 1, col + 2)) enemy++;

        if (HasEnemy(row + 1, col + 2)) enemy++;
        if (HasEnemy(row + 2, col + 1)) enemy++;

        if (HasEnemy(row + 2, col - 1)) enemy++;
        if (HasEnemy(row + 1, col - 2)) enemy++;

        return enemy;
    }

    private static bool HasEnemy(int row, int col)
    {
        if (!IsInsideOfRange(row, col))
        {
            return false;
        }

        return board[row][col] == 'K';
    }

    private static bool IsInsideOfRange(int row, int col)
    {
        if ((row < 0 || row >= board.Length) ||
            (col < 0 || col >= board[row].Length))
        {
            return false;
        }

        return true;
    }

    private static void PrintBoard()
    {
        Console.WriteLine();
        foreach (var row in board)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }

    private static void InitBoard()
    {
        board = null;
        bool isParsed = int.TryParse(Console.ReadLine(), out int n);
        if (isParsed)
        {
            board = new char[n][];
        }

        for (int row = 0; row < board.Length; row++)
        {
            board[row] = Console.ReadLine().Trim().ToCharArray();
        }
    }
}
