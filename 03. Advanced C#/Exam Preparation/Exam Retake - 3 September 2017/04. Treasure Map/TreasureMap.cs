using System;
using System.Text.RegularExpressions;

public class TreasureMap
{
    public static void Main()
    {
        string pattern = @"((?<sign>#)|!)[^#|!]*?(?<![a-zA-Z0-9])(?<name>[a-zA-Z]{4})(?![a-zA-Z0-9])[^#|!]*(?<!\d)(?<number>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#|!]*?(?(sign)!|#)";

        int numberOfInput = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInput; i++)
        {
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            Match correctMatch = matches[matches.Count / 2];

            string streetName = correctMatch.Groups["name"].Value;
            string streetNumber = correctMatch.Groups["number"].Value;
            string password = correctMatch.Groups["password"].Value;

            Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
        }
    }
}