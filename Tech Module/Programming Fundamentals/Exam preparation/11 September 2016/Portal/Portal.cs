using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    class Portal
    {
        private static char[][] matrix = null;
        private static int n;
        private static string directions;

        private static int startRow;
        private static int startCol;

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    Console.Write("|" + col);
                }
                Console.WriteLine("|");
            }
        }

        private static void InitMatrix()
        {
            n = int.Parse(Console.ReadLine());
            matrix = new char[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new char[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = 'X';
                }
            }
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();
                for (int j = 0; j < element.Length; j++)
                {
                    if (j < n)
                    {
                        if (element[j] == 'S')
                        {
                            startRow = i;
                            startCol = j;
                        }
                        matrix[i][j] = element[j];
                    }
                }
            }
        }

        private static bool ValidateIndex(int row, int col)
        {
            if (row < 0 || row >= matrix.Length)
            {
                return false;
            }

            if (col < 0 || col >= matrix[row].Length)
            {
                return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            InitMatrix();
            FillMatrix();
            directions = Console.ReadLine();

            int directionIndex = 0;
            int row = startRow;
            int col = startCol;
            int counter = 0;



            while (directionIndex < directions.Length)
            {
                counter++;
                switch (directions[directionIndex])
                {
                    case 'U':
                        // row -1
                        do
                        {
                            if (ValidateIndex(row - 1, col))
                            {
                                row -= 1;
                            }
                            else
                            {
                                row = matrix.Length - 1;
                            }
                        } while (matrix[row][col] == 'X');
                        break;
                    case 'D':
                        // row +1
                        do
                        {
                            if (ValidateIndex(row + 1, col))
                            {
                                row += 1;
                            }
                            else
                            {
                                row = 0;
                            }
                        } while (matrix[row][col] == 'X');
                        break;
                    case 'L':
                        //col -1
                        do
                        {
                            if (ValidateIndex(row, col - 1))
                            {
                                col -= 1;
                            }
                            else
                            {
                                col = matrix[row].Length - 1;
                            }
                        } while (matrix[row][col] == 'X');
                        break;
                    case 'R':
                        //col +1
                        do
                        {
                            if (ValidateIndex(row, col + 1))
                            {
                                col += 1;
                            }
                            else
                            {
                                col = 0;
                            }
                        } while (matrix[row][col] == 'X');
                        break;
                }

                if (matrix[row][col] == 'E')
                {

                    Console.WriteLine($"Experiment successful. {counter} turns required.");
                    return;
                }

                directionIndex++;
            }

            Console.WriteLine($"Robot stuck at {row} {col}. Experiment failed.");
        }
    }
}

