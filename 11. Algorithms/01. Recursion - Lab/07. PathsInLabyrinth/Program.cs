using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._PathsInLabyrinth
{
    public class Program
    {
        public enum Directions
        {
            S = 0,
            L = 1,
            R = 2,
            U = 3,
            D = 4
        }

        public static char visitedSign = 'x';

        public static char[][] lab = null;

        public static List<Directions> paths = new List<Directions>();

        private static void Main(string[] args)
        {
            lab = ReadLab();
            FindPaths(0, 0, Directions.S);
        }

        private static void FindPaths(int row, int col, Directions direction)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }

            paths.Add(direction);

            if (IsExit(row, col))
            {
                PrintPaths();
            }
            else if (!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, Directions.R);
                FindPaths(row, col - 1, Directions.L);
                FindPaths(row + 1, col, Directions.D);
                FindPaths(row - 1, col, Directions.U);
                Unmark(row, col);
            }

            paths.RemoveAt(paths.Count - 1);
        }

        private static bool IsVisited(int row, int col)
        {
            return lab[row][col] == visitedSign;
        }

        private static void Unmark(int row, int col)
        {
            lab[row][col] = '-';
        }

        private static void Mark(int row, int col)
        {
            lab[row][col] = visitedSign;
        }

        private static bool IsFree(int row, int col)
        {
            return lab[row][col] == '-';
        }

        private static void PrintPaths()
        {
            Console.WriteLine(string.Join("", paths.Skip(1)));
        }

        private static bool IsExit(int row, int col)
        {
            return lab[row][col] == 'e';
        }

        private static bool IsInBounds(int row, int col)
        {
            var isInBound = (row >= 0 && row < lab.Length) &&
                 (col >= 0 && col < lab[row].Length);
            return isInBound;
        }

        private static char[][] ReadLab()
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            var lab = new char[row][];

            for (var i = 0; i < row; i++)
            {
                lab[i] = new char[col];
                lab[i] = Console.ReadLine().ToCharArray();
            }

            return lab;
        }

        private static void PrintLab()
        {
            for (var i = 0; i < lab.Length; i++)
            {
                Console.WriteLine(string.Join("|", lab[i]));
            }
        }
    }
}