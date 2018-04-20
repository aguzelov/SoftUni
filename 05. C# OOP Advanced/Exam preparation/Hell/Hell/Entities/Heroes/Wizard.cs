public class Wizard : AbstractHero
{
    private const long InitialStrength = 25;
    private const long InitialAgility = 25;
    private const long InitialIntelligence = 100;
    private const long InitialHitPoints = 100;
    private const long InitialDamage = 250;

    public Wizard(string name)
        : base(name, InitialStrength, InitialAgility, InitialIntelligence, InitialHitPoints, InitialDamage)
    {
    }
}