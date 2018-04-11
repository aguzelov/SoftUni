using DependencyInversion.Attributes;
using DependencyInversion.Contracts;
using DependencyInversion.Models;
using DependencyInversion.Models.Strategies;
using System;
using System.Linq;
using System.Reflection;

namespace DependencyInversion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICalculator calculator = new Calculator(GetStrategy("+"));

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                if (tokens[0] == "mode")
                {
                    string @operator = tokens[1];
                    ICalculationStrategy strategy = GetStrategy(tokens[1]);
                    calculator.ChangeStrategy(strategy);
                }
                else
                {
                    int firstOperand = int.Parse(tokens[0]);
                    int secondOperand = int.Parse(tokens[1]);
                    int result = calculator.PerformCalculation(firstOperand, secondOperand);
                    Console.WriteLine(result);
                }
            }
        }

        public static ICalculationStrategy GetStrategy(string @operator)
        {
            Type[] strategyTypes = Assembly.GetExecutingAssembly().GetTypes();

            Type strategyType = null;
            foreach (var currentType in strategyTypes)
            {
                if (currentType.GetCustomAttribute<StrategyAttribute>()?.Name == @operator)
                {
                    strategyType = currentType;
                    break;
                }
            }

            ICalculationStrategy strategy = (ICalculationStrategy)Activator.CreateInstance(strategyType);

            return strategy;
        }
    }
}