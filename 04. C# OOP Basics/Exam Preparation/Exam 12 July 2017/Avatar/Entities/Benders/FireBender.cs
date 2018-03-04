public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression)
        : base(name, power, heatAggression, "Fire")
    {
    }

    public override string ToString()
    {
        return base.ToString("Heat Aggression");
    }
}