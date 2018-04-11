using DependencyInversion.Attributes;
using DependencyInversion.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversion.Models.Strategies
{
    [Strategy("*")]
    public class MultiplicationStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}