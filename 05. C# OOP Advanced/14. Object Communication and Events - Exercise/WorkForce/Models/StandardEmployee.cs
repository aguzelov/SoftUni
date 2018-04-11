using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Models
{
    public class StandardEmployee : Employee
    {
        private const int HOURS_PER_WEEK = 40;

        public StandardEmployee(string name) : base(name, HOURS_PER_WEEK)
        {
        }
    }
}