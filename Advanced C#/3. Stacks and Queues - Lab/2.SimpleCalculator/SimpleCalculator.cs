using System;
using System.Collections.Generic;
using System.Linq;

class SimpleCalculator
{
    static void Main()
    {
        string[] inputExpression = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        

        Stack<int> calculator = new Stack<int>();
        string operatorSign = "";

        foreach (var item in inputExpression)
        {
            switch (item)
            {
                case "+":
                    operatorSign = "+";
                    break;
                case "-":
                    operatorSign = "-";
                    break;
                default:
                    calculator.Push(int.Parse(item));
                    break;
            }

            if(calculator.Count == 2)
            {
                int rightOperand = calculator.Pop();
                int leftOperand = calculator.Pop();
                switch (operatorSign)
                {
                    case "+":
                        calculator.Push(leftOperand + rightOperand);
                        break;
                    case "-":
                        calculator.Push(leftOperand - rightOperand);
                        break;
                }
            }
        }

        Console.WriteLine(calculator.Peek());
    }
}
