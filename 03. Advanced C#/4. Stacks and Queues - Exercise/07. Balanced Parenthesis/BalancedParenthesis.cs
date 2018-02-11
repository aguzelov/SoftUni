using System;
using System.Collections.Generic;
using System.Linq;

class BalancedParenthesis
{
    static void Main()
    {
        string parentheses = Console.ReadLine();

        if (parentheses.Length % 2 != 0)
        {
            Console.WriteLine("NO");
            return;
        }

        Stack<char> singleParenthes = new Stack<char>();

        for (int i = 0; i < parentheses.Length; i++)
        {
            char current = parentheses[i];
            if (singleParenthes.Count == 0)
            {
                singleParenthes.Push(current);
            }
            else
            {
                if ((current == '}' && singleParenthes.Peek() == '{') ||
                    (current == ']' && singleParenthes.Peek() == '[') ||
                    (current == ')' && singleParenthes.Peek() == '('))
                {
                    singleParenthes.Pop();
                }
                else
                {
                    singleParenthes.Push(current);
                }
            }
        }

        if (singleParenthes.Count == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}