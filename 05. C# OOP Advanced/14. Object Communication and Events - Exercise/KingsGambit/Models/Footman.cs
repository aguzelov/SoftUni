public class Footman : Soldier
{
    public Footman(string name)
        : base(name)
    {
    }

    public override void KingUnderAttack()
    {
        System.Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}