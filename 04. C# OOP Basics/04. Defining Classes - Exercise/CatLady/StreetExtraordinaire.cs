public class StreetExtraordinaire : Cat
{
    public int Decibels { get; set; }

    public StreetExtraordinaire(string breed, string name, int decibels) : base(breed, name)
    {
        Decibels = decibels;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {Decibels}";
    }
}