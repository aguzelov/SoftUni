public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation)
        : base(name, power, groundSaturation, "Earth")
    {
    }

    public override string ToString()
    {
        return base.ToString("Ground Saturation");
    }
}