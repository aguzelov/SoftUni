public class Cymric : Cat
{
    public decimal FurLength { get; set; }

    public Cymric(string breed, string name, decimal furLength) : base(breed, name)
    {
        FurLength = furLength;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {FurLength:F2}";
    }
}