using System;
using System.Collections.Generic;

namespace _06._8QueensPuzzle
{
    public class Program
    {
        public const int Size = 8;
        public static bool[,] chessboard = new bool[Size, Size];
        public static int solutionsFound = 0;

        public static HashSet<int> attackedRows = new HashSet<int>();
        public static HashSet<int> attackedColums = new HashSet<int>();
        public static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        public static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        private static void Main(string[] args)
        {
            PutQueens(0);
            // Console.WriteLine($"{solutionsFound} solutions found!");
        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var positionOccupied = attackedRows.Contains(row) ||
                attackedColums.Contains(col) ||
                attackedLeftDiagonals.Contains(col - row) ||
                attackedRightDiagonals.Contains(row + col);

            return !positionOccupied;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedColums.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(row + col);
            chessboard[row, col] = true;
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColums.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(row + col);
            chessboard[row, col] = false;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    var sign = chessboard[row, col] == true ? '*' : '-';
                    Console.Write($"{sign} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            solutionsFound++;
        }
    }
}