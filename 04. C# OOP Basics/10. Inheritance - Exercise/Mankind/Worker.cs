using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal hoursPerDay;
    private decimal salaryPerHour;

    private decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    private decimal HoursPerDay
    {
        get
        {
            return this.hoursPerDay;
        }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.hoursPerDay = value;
        }
    }

    private decimal SalaryPerHour
    {
        get
        {
            return this.salaryPerHour;
        }
    }

    public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay) : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        HoursPerDay = hoursPerDay;
        CalculateHourSalary();
    }

    private void CalculateHourSalary()
    {
        this.salaryPerHour = this.weekSalary / (this.hoursPerDay * 5);
    }

    public override string ToString()
    {
        return base.ToString() +
               $"Week Salary: {this.WeekSalary:F2}{Environment.NewLine}" +
               $"Hours per day: {this.HoursPerDay:F2}{Environment.NewLine}" +
               $"Salary per hour: {this.SalaryPerHour:F2}";
    }
}