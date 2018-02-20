using System;

public class Stat
{
    private string name;
    private int level;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public int Level
    {
        get
        {
            return this.level;
        }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{Name} should be between 0 and 100.");
            }

            this.level = value;
        }
    }

    public Stat(string name, int level)
    {
        Name = name;
        Level = level;
    }
}