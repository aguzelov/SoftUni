using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversion.Attributes
{
    public class StrategyAttribute : Attribute
    {
        public StrategyAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}