using System;
using System.Collections.Generic;

class MatchingBrackets
{
    static void Main()
    {
        string expression = Console.ReadLine();

        Stack<int> indexes = new Stack<int>();

        for(int i = 0; i < expression.Length; i++)
        {
            if(expression[i] == '(')
            {
                indexes.Push(i);
            }

            if(expression[i] == ')')
            {
                int openingBracketIndex = indexes.Pop();

                Console.WriteLine(expression.Substring(openingBracketIndex, i - openingBracketIndex+1));
            }
        }
    }
}

