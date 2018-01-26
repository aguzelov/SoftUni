using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// ReSharper disable PossibleNullReferenceException


public class RadioactiveBunnies
{
    public static void Main()
    {
        var player = new Player();
        InitMatrix(out var matrix, ref player);


        var commands = Console.ReadLine().ToCharArray();
        for (var i = 0; i < commands.Length; i++)
        {
            
            Move(ref matrix, ref player, commands[i]);
            SpreadBunnies(ref matrix, ref player);


            if (!player.IsAlive || player.IsEscape)
            {
                break;
            }
        }

        if (!player.IsAlive)
        {
            PrintMatrix(ref matrix);
            Console.WriteLine($"dead: {player.position.Row} {player.position.Col}");
        }
        else if (player.IsEscape)
        {
            PrintMatrix(ref matrix);
            Console.WriteLine($"won: {player.position.Row} {player.position.Col}");
        }
    }

    private static void Move(ref char[][] matrix, ref Player player, char direction)
    {
        switch (direction)
        {
            case 'U':
                if (!IndexIsInside(ref matrix, player.position.Row - 1, player.position.Col))
                {
                    player.IsEscape = true;
                    matrix[player.position.Row][player.position.Col] = '.';
                    break;
                }

                if (matrix[player.position.Row - 1][player.position.Col] == 'B')
                {
                    player.IsAlive = false;
                }
                else
                {
                    matrix[player.position.Row - 1][player.position.Col] = 'P';
                    
                    matrix[player.position.Row][player.position.Col] = '.';
                }

                player.position.Row -= 1;
                break;
            case 'D':
                if (!IndexIsInside(ref matrix, player.position.Row + 1, player.position.Col))
                {
                    player.IsEscape = true;
                    matrix[player.position.Row][player.position.Col] = '.';
                    break;
                }

                if (matrix[player.position.Row + 1][player.position.Col] == 'B')
                {
                    player.IsAlive = false;
                }
                else
                {
                    matrix[player.position.Row + 1][player.position.Col] = 'P';

                    matrix[player.position.Row][player.position.Col] = '.';
                }

                player.position.Row += 1;
                break;
            case 'L':
                if (!IndexIsInside(ref matrix, player.position.Row, player.position.Col - 1))
                {
                    player.IsEscape = true;
                    matrix[player.position.Row][player.position.Col] = '.';
                    break;
                }

                if (matrix[player.position.Row][player.position.Col - 1] == 'B')
                {
                    player.IsAlive = false;
                }
                else
                {
                    matrix[player.position.Row][player.position.Col - 1] = 'P';
                    
                    matrix[player.position.Row][player.position.Col] = '.';
                }

                player.position.Col -= 1;
                break;
            case 'R':
                if (!IndexIsInside(ref matrix, player.position.Row, player.position.Col + 1))
                {
                    player.IsEscape = true;
                    matrix[player.position.Row][player.position.Col] = '.';
                    break;
                }
                
                if (matrix[player.position.Row][player.position.Col + 1] == 'B')
                {
                    player.IsAlive = false;
                }
                else
                {
                    matrix[player.position.Row][player.position.Col + 1] = 'P';
                    
                    matrix[player.position.Row][player.position.Col] = '.';
                }

                player.position.Col += 1;
                break;
        }

    }

    private static void SpreadBunnies(ref char[][] matrix, ref Player player)
    {
        HashSet<Position> positions = new HashSet<Position>();
        for (var row = 0; row < matrix.Length; row++)
        {
            for (var col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == 'B')
                {
                    positions.Add(new Position(row, col));
                }
            }
        }

        foreach (var position in positions)
        {
            SetBunnies(ref matrix, ref player, position.Row, position.Col);
        }
    }

    private static void SetBunnies(ref char[][] matrix, ref Player player,int row, int col)
    {
        if (IndexIsInside(ref matrix, row - 1, col))
        {
            if (matrix[row - 1][col] == 'P')
            {
                player.IsAlive = false;
            }
            matrix[row - 1][col] = 'B';
        }

        if (IndexIsInside(ref matrix, row + 1, col))
        {
            if (matrix[row + 1][col] == 'P')
            {
                player.IsAlive = false;
            }
            matrix[row + 1][col] = 'B';
        }

        if (IndexIsInside(ref matrix, row, col - 1))
        {
            if (matrix[row][col - 1] == 'P')
            {
                player.IsAlive = false;
            }
            matrix[row][col - 1] = 'B';
        }

        if (IndexIsInside(ref matrix, row, col + 1))
        {
            if (matrix[row][col + 1] == 'P')
            {
                player.IsAlive = false;
            }
            matrix[row][col + 1] = 'B';
        }
    }

    private static bool IndexIsInside(ref char[][] matrix, int row, int col)
    {
        if ((row < 0 || row >= matrix.Length) ||
            (col < 0 || col >= matrix[row].Length))
        {
            return false;
        }

        return true;
    }

    private static void InitMatrix(out char[][] matrix, ref Player player)
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var r = input[0];
        var c = input[1];

        matrix = new char[r][];

        for (var row = 0; row < matrix.Length; row++)
        {

            matrix[row] = Console.ReadLine().ToCharArray();
            if (matrix[row].Contains('P'))
            {
                for (var col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        player.position.Row = row;
                        player.position.Col = col;
                    }
                }
            }
        }
    }

    public static void PrintMatrix(ref char[][] matrix)
    {
        Console.WriteLine();
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join("", row));
        }
    }
}

public class Player
{
    public Position position;
    public bool IsAlive { get; set; } = true;
    public bool IsEscape { get; set; } = false;

    public Player()
    {
        this.position = new Position();
    }

    public void Move(char direction)
    {
        switch (direction)
        {
            case 'U':
                this.position.Row--;
                break;
            case 'D':
                this.position.Row++;
                break;
            case 'L':
                this.position.Col--;
                break;
            case 'R':
                this.position.Col++;
                break;
        }
    }
}

public class Position
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Position()
    {

    }

    public Position(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }
}
