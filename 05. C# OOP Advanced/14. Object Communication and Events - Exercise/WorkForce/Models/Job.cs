using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Models
{
    public delegate void JobCompleteHandler(Job job);

    public class Job
    {
        public event JobCompleteHandler JobComplete;

        private int hoursRequired;
        private string name;
        private Employee employee;

        public Job(string name, int hoursRequired, Employee employee)
        {
            this.name = name;
            this.hoursRequired = hoursRequired;
            this.employee = employee;
        }

        public void Update()
        {
            this.hoursRequired -= this.employee.HoursPerWeek;

            if (this.hoursRequired <= 0)
            {
                Console.WriteLine($"Job {this.name} done!");
                this.JobComplete?.Invoke(this);
            }
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.hoursRequired}";
        }
    }
}