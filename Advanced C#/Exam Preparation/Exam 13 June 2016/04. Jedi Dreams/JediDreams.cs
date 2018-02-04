using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class JediDreams
{
    public static Stack<Method> methods = new Stack<Method>();
    
    public static void Main()
    {
        GetCodeLines();
        
        Print();
    }

    private static void Print()
    {
        foreach (var method in methods.OrderByDescending(c => c.InvokeMethods.Count).ThenBy(n => n.Name))
        {
            if (method.InvokeMethods.Count == 0)
            {
                Console.WriteLine($"{method.Name} -> None");
            }
            else
            {
                Console.WriteLine($"{method.Name} -> {method.InvokeMethods.Count} -> {string.Join(", ", method.InvokeMethods.OrderBy(x => x))}");
            }
        }
    }
    
    private static void GetCodeLines()
    {
        int lineNumber = int.Parse(Console.ReadLine());

        string methodNamePattern = @"static\s+.*\s+([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";
        string invokesPattern = @"([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";


        for (int i = 0; i < lineNumber; i++)
        {
            string line = Console.ReadLine();
            
            Match methodNamesMatch = Regex.Match(line, methodNamePattern);
            MatchCollection invokesNameMatches = Regex.Matches(line, invokesPattern);

            if (methodNamesMatch.Success)
            {
                string methodName = methodNamesMatch.Groups[1].Value;
                
                methods.Push(new Method(methodName));
            }
            else
            {
                foreach (Match match in invokesNameMatches)
                {
                    string methodName = match.Groups[1].Value;
                    
                    methods.Peek().InvokeMethods.Add(methodName);
                }
            }
        }
    }
}

public class Method
{
    public string Name { get; set; }
    public List<string> InvokeMethods { get; set; }

    public Method(string name)
    {
        Name = name;
        InvokeMethods = new List<string>();
    }
}