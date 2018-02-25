using System;

public class SpecialisedSoldier : Soldier, IPrivate
{
    private decimal salary;
    private string corp;

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

    public string Corp
    {
        get
        {
            return this.corp;
        }
        private set
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new ArgumentException();
            }
            this.corp = value;
        }
    }

    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp)
        : base(id, firstName, lastName)
    {
        Salary = salary;
        Corp = corp;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Salary: {Salary:F2}{Environment.NewLine}" +
            $"Corps: {Corp}";
    }
}