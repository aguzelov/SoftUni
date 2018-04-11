using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversion.Contracts
{
    public interface ICalculator
    {
        void ChangeStrategy(ICalculationStrategy strategy);

        int PerformCalculation(int firstOperand, int secondOperand);
    }
}