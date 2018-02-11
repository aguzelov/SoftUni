using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class JediCodeX
{
    private static string encodedMessages;
    private static List<string> names = new List<string>();
    private static List<string> messages = new List<string>();

    public static void Main()
    {
        encodedMessages = GetMessage();

        string namePattern = Console.ReadLine();
        bool ValidateName(string x) => x.All(char.IsLetter);
        names = DecodeMessage(namePattern, ValidateName);

        string messagePattern = Console.ReadLine();
        bool ValidateMessage(string x) => x.All(char.IsLetterOrDigit);
        messages = DecodeMessage(messagePattern, ValidateMessage);


        Print();
    }
    
    private static List<string> DecodeMessage(string pattern, Func<string, bool> validate)
    {
        List<string> results = new List<string>();
        
        int indexOfPattern = encodedMessages.IndexOf(pattern);

        while (indexOfPattern >= 0)
        {
            int startIndexOfCandidate = indexOfPattern + pattern.Length;

            if (startIndexOfCandidate >= encodedMessages.Length - pattern.Length)
            {
                break;
            }

            int indexOfNextChar = startIndexOfCandidate + pattern.Length;
            if (char.IsLetter(encodedMessages[indexOfNextChar]) || 
                (validate(encodedMessages[indexOfNextChar].ToString()) && 
                 char.IsDigit(encodedMessages[indexOfNextChar])))
            {
                indexOfPattern = encodedMessages.IndexOf(pattern, indexOfPattern + 1);
                continue;
            }

            string candidate = encodedMessages.Substring(startIndexOfCandidate, pattern.Length);
            
            if (validate(candidate))
            {
                results.Add(candidate);
            }

            indexOfPattern = encodedMessages.IndexOf(pattern, indexOfPattern + 1);
        }


        return results;
    }

    private static void Print()
    {
        int[] indexes = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < names.Count; i++)
        {
            if ((i < indexes.Length) &&
                (indexes[i] > 0) &&
                (indexes[i] <= messages.Count))
            {
                result.Append($"{names[i]} - {messages[indexes[i] - 1]}{Environment.NewLine}");
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(result);
    }

    private static string GetMessage()
    {
        int n = int.Parse(Console.ReadLine());

        StringBuilder encodedMessage = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            encodedMessage.Append(line);
        }

        return encodedMessage.ToString();
    }
}