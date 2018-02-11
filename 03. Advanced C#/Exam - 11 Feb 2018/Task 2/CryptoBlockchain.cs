using System;

public class CryptoBlockchain
{
    private static char[][] room;

    private static Point sam;
    private static Point nikoladze;

    public static void Main()
    {
        var numberOfRows = int.Parse(Console.ReadLine());

        room = new char[numberOfRows][];

        for (var row = 0; row < numberOfRows; row++) room[row] = Console.ReadLine().ToCharArray();

        var directions = Console.ReadLine().ToCharArray();

        for (var i = 0; i < numberOfRows; i++)
        for (var j = 0; j < room[i].Length; j++)
        {
            if (room[i][j] == 'S') sam = new Point(i, j);

            if (room[i][j] == 'N') nikoladze = new Point(i, j);
        }

        foreach (var direction in directions)
        {
            MoveEnemy(ref room);
            if (HasFacingEnemy(sam))
            {
                Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                room[sam.Row][sam.Col] = 'X';
                break;
            }

            MoveSam(sam, direction);

            if (sam.Row == nikoladze.Row)
            {
                Console.WriteLine("Nikoladze killed!");
                room[nikoladze.Row][nikoladze.Col] = 'X';
                break;
            }
        }


        Print(room);
    }

    private static void MoveSam(Point sam, char direction)
    {
        switch (direction)
        {
            case 'U':
                sam.Row--;

                room[sam.Row][sam.Col] = 'S';
                room[sam.Row + 1][sam.Col] = '.';
                break;
            case 'D':
                sam.Row++;
                room[sam.Row][sam.Col] = 'S';
                room[sam.Row - 1][sam.Col] = '.';
                break;
            case 'L':
                sam.Col--;
                room[sam.Row][sam.Col] = 'S';
                room[sam.Row][sam.Col + 1] = '.';
                break;
            case 'R':
                sam.Col++;
                room[sam.Row][sam.Col] = 'S';
                room[sam.Row][sam.Col - 1] = '.';
                break;
            case 'W':
                return;
        }
    }

    private static bool HasFacingEnemy(Point sam)
    {
        for (var col = 0; col < room[sam.Row].Length; col++)
        {
            if (room[sam.Row][col] == 'b' && col < sam.Col) return true;

            if (room[sam.Row][col] == 'd' && col > sam.Col) return true;
        }

        return false;
    }


    private static void MoveEnemy(ref char[][] room)
    {
        for (var row = 0; row < room.Length; row++)
        for (var col = 0; col < room[row].Length; col++)
            if (room[row][col] == 'b')
                if (col == room[row].Length - 1)
                {
                    room[row][col] = 'd';
                }
                else
                {
                    room[row][col + 1] = 'b';
                    room[row][col] = '.';
                    col++;
                }
            else if (room[row][col] == 'd')
                if (col == 0)
                {
                    room[row][col] = 'b';
                }
                else
                {
                    room[row][col - 1] = 'd';
                    room[row][col] = '.';
                    col--;
                }
    }

    private static void Print(char[][] room)
    {
        foreach (var row in room) Console.WriteLine(string.Join("", row));
    }
}

public class Point
{
    public Point(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public int Row { get; set; }
    public int Col { get; set; }
}