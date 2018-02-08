using System;
using System.Linq;

public class Monopoly
{
    private static char[][] _board;
    public static void Main()
    {
        InitMatrix();

        bool isLeft = true;
        Player player = new Player();
        for (int row = 0; row < _board.Length; row++)
        {
            if (isLeft)
            {
                Left(ref player, row);
                isLeft = false;
            }
            else
            {
                Right(ref player, row);
                isLeft = true;
            }

        }

        Console.WriteLine(player.ToString());
    }

    private static void Left(ref Player player, int row)
    {
        for (int col = 0; col < _board[row].Length; col++)
        {
            char symbol = _board[row][col];
            player.Step(symbol, row, col);
        }
    }

    private static void Right(ref Player player, int row)
    {
        for (int col = _board[row].Length - 1; col >= 0; col--)
        {
            char symbol = _board[row][col];
            player.Step(symbol, row, col);
        }
    }

    private static void InitMatrix()
    {
        int[] rowAndCol = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        _board = new char[rowAndCol[0]][];
        for (int row = 0; row < _board.Length; row++)
        {
            _board[row] = Console.ReadLine().ToCharArray();
        }
    }
}

public class Player
{
    public int Money { get; set; }
    public int Turns { get; set; }

    private int hotelCounter;

    public Player()
    {
        Money = 50;
        Turns = 0;
        hotelCounter = 0;
    }

    public void Step(char symbol, int row, int col)
    {
        switch (symbol)
        {
            case 'H':
                hotelCounter++;
                Console.WriteLine($"Bought a hotel for {Money}. Total hotels: {hotelCounter}.");
                Money = 0;
                break;
            case 'J':
                Console.WriteLine($"Gone to jail at turn {Turns}.");
                Turns += 2;
                Money += (hotelCounter * 10)*2;
                break;
            case 'S':
                int spendMoney =Math.Min((row + 1) * (col + 1),Money);
                Console.WriteLine($"Spent {spendMoney} money at the shop.");
                Money -= spendMoney;
                
                break;
        }

        Money += hotelCounter * 10;
        Turns++;
    }

    public override string ToString()
    {
        return $"Turns {Turns}{Environment.NewLine}Money {Money}";
    }
}