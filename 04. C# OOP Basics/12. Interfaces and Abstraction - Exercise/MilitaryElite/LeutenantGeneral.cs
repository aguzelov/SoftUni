using System;
using System.Collections.Generic;

public class LeutenantGeneral : Soldier, IPrivate, ILeutennantGeneral
{
    private decimal salary;
    private List<Private> privates;

    public decimal Salary
    {
        get
        {
            return this.salary;
        }
        private set
        {
            this.salary = value;
        }
    }

    public IReadOnlyList<Private> Privates
    {
        get
        {
            return this.privates;
        }
    }

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName)
    {
        Salary = salary;
        this.privates = new List<Private>();
    }

    public void AddPrivate(Private @private)
    {
        this.privates.Add(@private);
    }

    public override string ToString()
    {
        string privates = Privates.Count == 0 ? string.Empty : $"{Environment.NewLine}" + string.Join($"{Environment.NewLine}", Privates);

        return $"{base.ToString()} Salary: {Salary:F2}{Environment.NewLine}" +
            $"Privates:{privates}";
    }
}