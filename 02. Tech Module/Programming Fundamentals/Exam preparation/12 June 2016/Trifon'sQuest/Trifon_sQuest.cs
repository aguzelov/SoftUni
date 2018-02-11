using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trifon_sQuest
{
    class Trifon_sQuest
    {
        private static long health;
        private static char[][] matrix = null;
        private static long row;
        private static long col;

        static void Main(string[] args)
        {
            health = long.Parse(Console.ReadLine());
            InitMatrix();
            Start();
        }

        private static void Start()
        {
            row = 0;
            col = 0;
            string symbol;
            long endRow = matrix[0].Length % 2 == 0 ? 0 : matrix.Length - 1;

            long turns = 0;

            bool GoingDown = true;
            while (true)
            {
                if (health <= 0)
                {
                    Console.WriteLine($"Died at: [{row}, {col}]");
                    return;
                }
                if (GoingDown)
                {
                    symbol = matrix[row][col].ToString();
                    Obstacles(symbol, ref turns);
                    row++;
                    if (row >= matrix.Length)
                    {
                        row = matrix.Length - 1;
                        col++;
                        GoingDown = false;
                    }
                }
                else
                {
                    symbol = matrix[row][col].ToString();
                    Obstacles(symbol, ref turns);
                    row--;
                    if (row == -1)
                    {
                        row = 0;
                        col++;
                        GoingDown = true;
                    }
                }


                if (row == endRow && col >= matrix[0].Length)
                {
                    Console.WriteLine("Quest completed!");
                    Console.WriteLine("Health: " + health);
                    Console.WriteLine("Turns: " + turns);
                    return;
                }
            }
        }

        private static void Obstacles(string symbol, ref long turns)
        {
            switch (symbol)
            {
                case "F":
                    health -= (turns / 2);
                    if (health <= 0)
                    {
                        Console.WriteLine($"Died at: [{row}, {col}]");
                        Environment.Exit(0);
                        return;
                    }
                    break;
                case "H":

                    health += (turns / 3);
                    break;
                case "T":

                    turns += 2;
                    break;
            }
            turns++;
        }

        private static void Print()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine("|" + string.Join("|", row) + "|");
            }
        }

        private static void InitMatrix()
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            matrix = new char[dimensions[0]][];
            for (int row = 0; row < matrix.Length; row++)
            {
                string line = Console.ReadLine();
                matrix[row] = new char[dimensions[1]];
                for (int i = 0; i < dimensions[1]; i++)
                {
                    matrix[row][i] = line[i];
                }

            }
        }
    }
}
