using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable AssignNullToNotNullAttribute


public class MatrixOfPalindromes
{
    private static readonly char[] _alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

    public static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = input[0];
        var c = input[1];

       
        var matrix = new string[r][];
        for (var i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new string[c];
        }

        for (var row = 0; row < r; row++)
        {
            for (var col = 0; col < c; col++)
            {
                matrix[row][col] = $"{_alphabet[row]}{_alphabet[col+row]}{_alphabet[row]}";
            }
        }

        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
            
        }
    }
}