using System;

class Patient
{
    private string name;

    public string Name
    {
        get { return name; }
    }

    public Patient()
    {
        this.name = string.Empty;
    }

    public Patient(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return $"{name}";
    }
}
