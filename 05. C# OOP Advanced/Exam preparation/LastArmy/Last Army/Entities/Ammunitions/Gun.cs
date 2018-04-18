public class Gun : Ammunition
{
    public const double InitWeight = 1.4;

    public Gun(string name)
        : base(name, InitWeight)
    {
    }
}