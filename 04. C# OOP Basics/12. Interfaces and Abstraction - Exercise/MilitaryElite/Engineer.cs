using System;
using System.Collections.Generic;

public class Engineer : SpecialisedSoldier
{
    private List<Repair> repairs;

    public IReadOnlyList<Repair> Repairs
    {
        get
        {
            return this.repairs;
        }
    }

    public Engineer(int id, string firstName, string lastName, decimal salary, string corp)
        : base(id, firstName, lastName, salary, corp)
    {
        this.repairs = new List<Repair>();
    }

    public void AddRepair(Repair repair)
    {
        this.repairs.Add(repair);
    }

    public override string ToString()
    {
        string missions = Repairs.Count == 0 ? string.Empty : $"{Environment.NewLine}" + string.Join($"{Environment.NewLine}", Repairs);

        return $"{base.ToString()}{Environment.NewLine}" +
            $"Repairs:{missions}";
    }
}