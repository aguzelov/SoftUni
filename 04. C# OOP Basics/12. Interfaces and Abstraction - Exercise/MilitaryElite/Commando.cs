using System;
using System.Collections.Generic;

public class Commando : SpecialisedSoldier
{
    private List<Mission> missions;

    public IReadOnlyList<Mission> Missions
    {
        get
        {
            return this.missions;
        }
    }

    public Commando(int id, string firstName, string lastName, decimal salary, string corp)
        : base(id, firstName, lastName, salary, corp)
    {
        this.missions = new List<Mission>();
    }

    public void AddMission(Mission mission)
    {
        this.missions.Add(mission);
    }

    public override string ToString()
    {
        string missions = Missions.Count == 0 ? string.Empty : $"{Environment.NewLine}" + string.Join($"{Environment.NewLine}", Missions);

        return $"{base.ToString()}{Environment.NewLine}" +
            $"Missions:{missions}";
    }
}