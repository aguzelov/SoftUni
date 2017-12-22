using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator_CSharp.Models
{
    public class Calculator
    {
        public decimal LeftOperand { get; set; }

        public decimal RightOperand { get; set; }

        public string Operator { get; set; }

        public decimal Result { get; set; }

        public Calculator()
        {
            this.Result = 0;
        }
    }
}