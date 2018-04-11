using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Models
{
    public abstract class Employee
    {
        protected Employee(string name, int hoursPerWeek)
        {
            this.Name = name;
            this.HoursPerWeek = hoursPerWeek;
        }

        public string Name { get; private set; }

        public int HoursPerWeek { get; private set; }
    }
}