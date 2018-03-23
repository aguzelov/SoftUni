using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        Stack<string> stack = new Stack<string>();

        while (true)
        {
            string[] inputArgs = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputArgs[0];

            string result = string.Empty;
            switch (command)
            {
                case "Push":
                    stack.Push(inputArgs.Skip(1).ToArray());
                    break;

                case "Pop":
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        result = ioe.Message;
                    }
                    break;

                case "END":
                    result = string.Join($"{Environment.NewLine}", stack);
                    result += Environment.NewLine + result;
                    break;
            }

            if (result != string.Empty) Console.WriteLine(result);

            if (command == "END") break;
        }
    }
}