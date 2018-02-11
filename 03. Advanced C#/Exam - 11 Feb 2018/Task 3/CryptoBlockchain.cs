using System;
using System.Text;
using System.Text.RegularExpressions;

public class Sneaking
{
    public static void Main()
    {
        var row = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();
        for (var i = 0; i < row; i++) sb.Append(Console.ReadLine());

        var line = sb.ToString();

        var pattern = @"((\{)[^[{]*?(?<digits>\d+)[^]}]*?(\}))|((\[)[^[{]*?(?<digits>\d+)[^]}]*?(\]))";

        sb.Clear();

        var matches = Regex.Matches(line, pattern);

        foreach (Match match in matches)
        {
            var blockLenght = match.Length;
            var digits = match.Groups["digits"].Value;
            if (digits.Length % 3 != 0) continue;

            var startIndex = 0;
            while (startIndex < digits.Length)
            {
                for (var i = 0; i < 3; i++) sb.Append(digits[startIndex + i]);

                startIndex += 3;

                var threeDigit = sb.ToString();
                var number = int.Parse(threeDigit);
                var asciiCode = number - blockLenght;
                Console.Write((char) asciiCode);

                sb.Clear();
            }
        }
    }
}