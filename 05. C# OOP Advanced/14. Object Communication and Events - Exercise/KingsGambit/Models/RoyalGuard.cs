public class RoyalGuard : Soldier
{
    public RoyalGuard(string name)
        : base(name)
    {
    }

    public override void KingUnderAttack()
    {
        System.Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}