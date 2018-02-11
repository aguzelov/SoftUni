using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetMultiplier
{
    class TargetMultiplier
    {

        private static List<List<long>> matrix = new List<List<long>>();
        private static int targetRow;
        private static int targetCol;

        private static void InitMatrix()
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < dimensions[0]; i++)
            {
                List<long> list = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
                matrix.Add(list);
            }
        }

        private static void Print()
        {
            foreach (var list in matrix)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }

        private static bool ValidateIndexes(int row, int col)
        {
            if (row < 0 || row >= matrix.Count)
            {
                return false;
            }

            if (col < 0 || col >= matrix[row].Count)
            {
                return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            InitMatrix();

            int[] targetInput = Console.ReadLine()
                                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();
            targetRow = targetInput[0];
            targetCol = targetInput[1];

            long sum = 0;

            for (int row = targetRow - 1; row <= targetRow + 1; row++)
            {

                for (int col = targetCol - 1; col <= targetCol + 1; col++)
                {
                    if (ValidateIndexes(row, col) && (row != targetRow || col != targetCol))
                    {
                        sum += matrix[row][col];
                        matrix[row][col] *= matrix[targetRow][targetCol];
                    }
                }
            }
            matrix[targetRow][targetCol] = matrix[targetRow][targetCol] * sum;

            Print();
        }
    }
}
