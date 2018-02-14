using System;

public class Pokemon
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Pokemon()
    {
    }

    public Pokemon(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public override string ToString()
    {
        return $"{Name} {Type}";
    }
}
