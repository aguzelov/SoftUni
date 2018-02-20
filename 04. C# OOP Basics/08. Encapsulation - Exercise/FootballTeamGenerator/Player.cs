using System;

public class Player
{
    private string name;
    private Endurance endurance;
    private Sprint sprint;
    private Dribble dribble;
    private Passing passing;
    private Shooting shooting;
    private double skillLevel;

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    private int Endurance
    {
        set
        {
            this.endurance = new Endurance(value);
        }
    }

    private int Sprint
    {
        set
        {
            this.sprint = new Sprint(value);
        }
    }

    private int Dribble
    {
        set
        {
            this.dribble = new Dribble(value);
        }
    }

    private int Passing
    {
        set
        {
            this.passing = new Passing(value);
        }
    }

    private int Shooting
    {
        set
        {
            this.shooting = new Shooting(value);
        }
    }

    public double SkillLevel
    {
        get
        {
            CalculateSkillLevel();
            return this.skillLevel;
        }
    }

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public void CalculateSkillLevel()
    {
        double average = ((double)endurance.Level + sprint.Level + dribble.Level + passing.Level + shooting.Level) / 5;
        this.skillLevel = average;
    }

    private bool Equals(Player other)
    {
        return this.name == other.Name;
    }

    public override bool Equals(object obj)
    {
        var other = obj as Player;
        if (other == null)
        {
            return false;
        }

        return this.Equals(other);
    }

    public override int GetHashCode()
    {
        return this.GetHashCode();
    }
}