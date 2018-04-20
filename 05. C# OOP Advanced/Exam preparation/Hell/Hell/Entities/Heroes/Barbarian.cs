public class Barbarian : AbstractHero
{
    private const long InitialStrength = 90;
    private const long InitialAgility = 25;
    private const long InitialIntelligence = 10;
    private const long InitialHitPoints = 350;
    private const long InitialDamage = 150;

    public Barbarian(string name)
        : base(name, InitialStrength, InitialAgility, InitialIntelligence, InitialHitPoints, InitialDamage)
    {
    }
}