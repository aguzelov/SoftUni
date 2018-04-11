public class Footman : Soldier
{
    private const int InitialHealth = 2;

    public Footman(string name)
        : base(name, InitialHealth)
    {
    }

    public override void KingUnderAttack()
    {
        System.Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}