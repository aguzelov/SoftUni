using System;
using System.Text;
using System.Text.RegularExpressions;

public class CubicMessages
{
    public static void Main()
    {
        while (TakeMessage(out string message))
        {
            string pattern = @"^(\d+)(?<message>[a-zA-Z]+)([^a-zA-Z]*)$";

            Match match = Regex.Match(message, pattern);

            if (!match.Success)
            {
                continue;
            }

            int m = int.Parse(Console.ReadLine());

            message = match.Groups["message"].Value;

            if (m != message.Length)
            {
                continue;
            }

            string leftPart = match.Groups[1].Value;
            string rightPart = match.Groups[2].Value;

            GenerateVerificationCode(message, leftPart + rightPart);
        }
    }

    private static void GenerateVerificationCode(string message, string indexInMessage)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var i in indexInMessage)
        {
            int index = 0;
            bool hasParsed = int.TryParse(i.ToString(),out index);
            if (!hasParsed) continue;

            sb.Append((index < 0 || index >= message.Length) ? " " : message[index].ToString());

        }

        Console.WriteLine($"{message} == {sb.ToString()}");
    }

    private static bool TakeMessage(out string message)
    {
        message = String.Empty;

        string input = Console.ReadLine();
        if (input == "Over!") return false;

        message = input;
        return true;
    }
}
