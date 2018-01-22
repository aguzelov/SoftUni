using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable PossibleNullReferenceException

public class SimpleTextEditor
{
    private static List<char> _text= new List<char>();
    private static Stack<string> _stack = new Stack<string>();

    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (var i = 0; i < n; i++)
        {
            var commandAndArgument =Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            switch (commandAndArgument[0])
            {
                case "1":
                    AppendToText(commandAndArgument[1]);
                    break;
                case "2":
                    EraseLastNElements(int.Parse(commandAndArgument[1]));
                    break;
                case "3":
                    ReturnElementAtIndex(int.Parse(commandAndArgument[1])-1);
                    break;
                case "4":
                    Undo();
                    break;
            }
        }
    }

    private static void Undo()
    {
        _text.Clear();
        foreach (var c in _stack.Pop())
        {
            _text.Add(c);
        }
    }

    private static void ReturnElementAtIndex(int index)
    {
        
        if (index < 0 || index >= _text.Count)
        {
            return;
        }

        Console.WriteLine(_text[index]);
    }

    private static void EraseLastNElements(int n)
    {
        _stack.Push(string.Join("",_text));

        if (n >= _text.Count)
        {
            _text.Clear();
            return;
        }

        for (var i = 0; i < n; i++)
        {
            _text.RemoveAt(_text.Count-1);
        }
        
    }

    private static void AppendToText(string s)
    {
        _stack.Push(string.Join("", _text));

        foreach (var c in s)
        {
            _text.Add(c);
        }
    }
}

