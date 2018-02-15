public class Siamese : Cat
{
    public int EarSize { get; set; }

    public Siamese(string breed, string name, int earSize) : base(breed, name)
    {
        EarSize = earSize;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {EarSize}";
    }
}