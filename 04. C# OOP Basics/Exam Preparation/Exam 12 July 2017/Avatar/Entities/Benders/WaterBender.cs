public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity)
         : base(name, power, waterClarity, "Water")
    {
    }

    public override string ToString()
    {
        return base.ToString("Water Clarity");
    }
}