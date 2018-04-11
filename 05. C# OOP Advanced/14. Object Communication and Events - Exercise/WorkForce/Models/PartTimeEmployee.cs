using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Models
{
    public class PartTimeEmployee : Employee
    {
        private const int HOURS_PER_WEEK = 20;

        public PartTimeEmployee(string name)
            : base(name, HOURS_PER_WEEK)
        {
        }
    }
}