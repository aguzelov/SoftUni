using DependencyInversion.Attributes;
using DependencyInversion.Contracts;

namespace DependencyInversion.Models.Strategies
{
    [Strategy("+")]
    public class AdditionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}