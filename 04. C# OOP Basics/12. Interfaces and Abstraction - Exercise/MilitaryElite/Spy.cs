using System;

public class Spy : Soldier
{
    private int codeNumber;

    public int CodeNumber
    {
        get
        {
            return this.codeNumber;
        }
        private set
        {
            this.codeNumber = value;
        }
    }

    public Spy(int id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        return $"{base.ToString()}{Environment.NewLine}" +
            $"Code Number: {CodeNumber}";
    }
}