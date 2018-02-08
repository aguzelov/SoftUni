using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;


public class SoftuniNumerals
{
    private static Dictionary<string, string> values = new Dictionary<string, string>()
    {
        { "aa", "0" },
        { "aba", "1" },
        { "bcc", "2" },
        { "cc", "3" },
        { "cdc", "4" }
    };

    public static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();
        Queue<char> chars = new Queue<char>(input);

        StringBuilder sb = new StringBuilder();

        string number = String.Empty;
        while (chars.Count != 0)
        {
            sb.Append(chars.Dequeue());

            if (values.ContainsKey(sb.ToString()))
            {
                number += values[sb.ToString()];
                sb.Clear();
            }
        }

        ConvertToDecimal(number);
    }

    private static void ConvertToDecimal(string numbers)
    {
        BigInteger power = 1;
        BigInteger decimalNumer = 0;
        for (int index = numbers.Length - 1; index >= 0; index--)
        {
            int number = int.Parse(numbers[index].ToString());
            decimalNumer += number * power;

            power *= 5;
        }

        Console.WriteLine(decimalNumer);
    }
}