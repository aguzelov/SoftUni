using System;
using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team()
    {
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public Team(string name) : this()
    {
        this.name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public IReadOnlyCollection<Person> FirstTeam { get { return firstTeam; } }

    public IReadOnlyCollection<Person> ReserveTeam { get { return reserveTeam; } }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }
}