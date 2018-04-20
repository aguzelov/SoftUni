public class Assassin : AbstractHero
{
    private const long InitialStrength = 25;
    private const long InitialAgility = 100;
    private const long InitialIntelligence = 15;
    private const long InitialHitPoints = 150;
    private const long InitialDamage = 300;

    public Assassin(string name)
        : base(name, InitialStrength, InitialAgility, InitialIntelligence, InitialHitPoints, InitialDamage)
    {
    }
}