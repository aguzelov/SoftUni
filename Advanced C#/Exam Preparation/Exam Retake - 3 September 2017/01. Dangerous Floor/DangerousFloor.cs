using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class DangerousFloor
{
    private static string[][] _board;

    public static void Main()
    {
        InitBoard();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            Piece.GetInfo(input);
            
            if (_board[Piece.CurrentPos.Row][Piece.CurrentPos.Col] != Piece.PeiceSymbol)
            {
                OutputMessage.ThereIsNoSuchAPiece();
                continue;
            }
            

            if (!Piece.IsValid)
            {
                OutputMessage.InvalidMove();
                continue;
            }

            if (!IsInRange(Piece.NewPos))
            {
                OutputMessage.MoveGoOutOfBoard();
                continue;
            }

            _board[Piece.CurrentPos.Row][Piece.CurrentPos.Col] = "x";
            _board[Piece.NewPos.Row][Piece.NewPos.Col] = Piece.PeiceSymbol;
        }
    }

    private static bool IsInRange(Position position)
    {
        if ((position.Row < 0 || position.Row >= _board.Length) ||
            (position.Col < 0 || position.Col >= _board[position.Row].Length))
        {
            return false;
        }

        return true;
    }
    
    private static void InitBoard()
    {
        _board = new string[8][];

        for (int row = 0; row < _board.Length; row++)
        {
            _board[row] = Console.ReadLine().Split(new []{','},StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}

public static class Piece
{
    public static string PeiceSymbol { get; set; }
    public static Position CurrentPos { get; set; }
    public static Position NewPos { get; set; }
    public static bool IsValid { get; set; }
    
    public static void GetInfo(string info)
    {
        IsValid = false;
        string pattern = @"^([A-Z]{1})(\d{1})(\d{1})-(\d{1})(\d{1})$";
        Match match = Regex.Match(info, pattern);
        if (match.Success)
        {
            PeiceSymbol = match.Groups[1].Value;
            int currentRow = int.Parse(match.Groups[2].Value);
            int currentCol = int.Parse(match.Groups[3].Value);
            CurrentPos = new Position(currentRow, currentCol);

            int newRow = int.Parse(match.Groups[4].Value);
            int newCol = int.Parse(match.Groups[5].Value);
            NewPos = new Position(newRow, newCol);
        }

        SetValidMoves();
    }

    private static void SetValidMoves()
    {
        switch (PeiceSymbol)
        {
            case "K":
                for (int row = CurrentPos.Row - 1; row <= CurrentPos.Row + 1; row++)
                {
                    for (int col = CurrentPos.Col - 1; col <= CurrentPos.Col + 1; col++)
                    {
                        if (row == NewPos.Row && col == NewPos.Col) IsValid = true;
                    }
                }
                break;
            case "R":
                if (CurrentPos.Row == NewPos.Row || CurrentPos.Col == NewPos.Col) IsValid = true;
                break;
            case "B":
                if (Math.Abs(NewPos.Row - CurrentPos.Row) == Math.Abs(NewPos.Col - CurrentPos.Col)) IsValid = true;
                break;
            case "Q":
                if (CurrentPos.Row == NewPos.Row || CurrentPos.Col == NewPos.Col) IsValid = true;

                if (Math.Abs(NewPos.Row - CurrentPos.Row) == Math.Abs(NewPos.Col - CurrentPos.Col)) IsValid = true;

                break;
            case "P":
                if (NewPos.Col == CurrentPos.Col && NewPos.Row == CurrentPos.Row-1) IsValid = true;
                break;
        }
    }
}

public class Position
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Position(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public override int GetHashCode()
    {
        return this.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Position item)) return false;

        return this.Equals(item);
    }

    public bool Equals(Position other)
    {
        if (other == null) return false;

        return this.Row == other.Row && this.Col == other.Col;
    }
}

public static class OutputMessage
{
    public static void ThereIsNoSuchAPiece()
    {
        Console.WriteLine("There is no such a piece!");
    }

    public static void InvalidMove()
    {
        Console.WriteLine("Invalid move!");
    }

    public static void MoveGoOutOfBoard()
    {
        Console.WriteLine("Move go out of board!");
    }
}