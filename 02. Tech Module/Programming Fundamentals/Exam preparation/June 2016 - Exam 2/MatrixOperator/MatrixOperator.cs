using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperator
{
    class MatrixOperator
    {
        private static List<List<int>> matrix = new List<List<int>>();

        private static void InitMatrix()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<int> array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                matrix.Add(array);
            }
        }

        private static void Print()
        {
            foreach (var list in matrix)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }

        private static bool ValidateIndex(int row, int index)
        {
            if (index < 0 || index >= matrix[row].Count)
            {
                return false;
            }
            return true;
        }

        private static bool ValidateIndex(int index)
        {
            if (index < 0 || index >= matrix.Count)
            {
                return false;
            }
            return true;
        }

        private static void Remove(string type, string position, int index)
        {
            if (type == "positive")
            {
                if (position == "row")
                {
                    if (ValidateIndex(index))
                    {
                        matrix[index].RemoveAll(x => x >= 0);
                    }
                }
                else if (position == "col")
                {
                    for (int i = 0; i < matrix.Count; i++)
                    {
                        if (ValidateIndex(i, index))
                        {
                            if (matrix[i][index] >= 0)
                            {
                                matrix[i].RemoveAt(index);
                            }
                        }
                    }
                }
            }
            else if (type == "negative")
            {
                if (position == "row")
                {
                    if (ValidateIndex(index))
                    {
                        matrix[index].RemoveAll(x => x < 0);
                    }
                }
                else if (position == "col")
                {
                    for (int i = 0; i < matrix.Count; i++)
                    {
                        if (ValidateIndex(i, index))
                        {
                            if (matrix[i][index] < 0)
                            {
                                matrix[i].RemoveAt(index);
                            }
                        }
                    }
                }
            }
            else if (type == "odd")
            {
                if (position == "row")
                {
                    if (ValidateIndex(index))
                    {
                        matrix[index].RemoveAll(x => x % 2 != 0);
                    }
                }
                else if (position == "col")
                {
                    for (int i = 0; i < matrix.Count; i++)
                    {
                        if (ValidateIndex(i, index))
                        {
                            if (matrix[i][index] % 2 != 0)
                            {
                                matrix[i].RemoveAt(index);
                            }
                        }
                    }
                }
            }
            else if (type == "even")
            {
                if (position == "row")
                {
                    if (ValidateIndex(index))
                    {
                        matrix[index].RemoveAll(x => x % 2 == 0);
                    }
                }
                else if (position == "col")
                {
                    for (int i = 0; i < matrix.Count; i++)
                    {
                        if (ValidateIndex(i, index))
                        {
                            if (matrix[i][index] % 2 == 0)
                            {
                                matrix[i].RemoveAt(index);
                            }
                        }
                    }
                }
            }
        }

        private static void Swap(int firstRow, int secondRow)
        {
            if (ValidateIndex(firstRow) && ValidateIndex(secondRow))
            {
                List<int> first = matrix[firstRow];
                matrix[firstRow] = matrix[secondRow];
                matrix[secondRow] = first;
            }
        }

        private static void Insert(int row, int number)
        {
            if (ValidateIndex(row))
            {
                matrix[row].Insert(0, number);
            }
        }

        private static bool TakeCommand()
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                return false;
            }

            string[] command = input.Split(' ').ToArray();

            switch (command[0])
            {
                case "remove":
                    string type = command[1];
                    string position = command[2];
                    int index = int.Parse(command[3]);
                    Remove(type, position, index);
                    break;
                case "swap":
                    int firstRow = int.Parse(command[1]);
                    int secondRow = int.Parse(command[2]);
                    Swap(firstRow, secondRow);
                    break;
                case "insert":
                    int row = int.Parse(command[1]);
                    int number = int.Parse(command[2]);
                    Insert(row, number);
                    break;
            }
            return true;
        }

        static void Main(string[] args)
        {
            InitMatrix();

            while (TakeCommand()) { }

            Print();
        }
    }
}
