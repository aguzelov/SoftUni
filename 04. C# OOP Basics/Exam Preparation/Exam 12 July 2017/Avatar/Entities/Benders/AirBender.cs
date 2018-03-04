public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity)
         : base(name, power, aerialIntegrity, "Air")
    {
    }

    public override string ToString()
    {
        return base.ToString("Aerial Integrity");
    }
}