using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class BasicMarkupLanguage
{

    private static int lineCounter = 1;

    public static void Main()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (input == "<stop/>") break;

            ReadInput(input);
        }
    }

    private static void ReadInput(string input)
    {
        Match tagMatch = Regex.Match(input, @"<\s*([a-zA-Z]+)\s*");
        string tagName = tagMatch.Groups[1].Value;

        Match contentMatch = Regex.Match(input, @"(content\s*=\s*""(.+?)"")");
        string content = contentMatch.Groups[2].Value;
        if (content == "") return;

        if (tagName == "repeat")
        {
            Match valueMatch = Regex.Match(input, @"(value\s*=\s*\\?""\s*(\d+?)\s*\\?"")");
            int value = int.Parse(valueMatch.Groups[2].Value);

            Repeat(content, value);

        }
        else if (tagName == "inverse")
        {
            Inverse(content);

        }
        else if (tagName == "reverse")
        {
            Reverse(content);
        }
    }

    private static void Inverse(string content)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < content.Length; i++)
        {
            char c = content[i];
            sb.Append(char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c));
        }

        Console.WriteLine($"{lineCounter++}. {sb.ToString()}");
    }

    private static void Reverse(string content)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = content.Length - 1; i >= 0; i--)
        {
            sb.Append(content[i]);
        }

        Console.WriteLine($"{lineCounter++}. {sb.ToString()}");
    }

    private static void Repeat(string content, int value)
    {
        for (int i = 0; i < value; i++)
        {
            Console.WriteLine($"{lineCounter++}. {content}");
        }
    }
}