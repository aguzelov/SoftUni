public delegate void KingUnderAttackHandler();

public class King : INamed
{
    public King(string name)
    {
        this.Name = name;
    }

    public event KingUnderAttackHandler UnderAttack;

    public string Name { get; private set; }

    public void OnAttack()
    {
        System.Console.WriteLine($"King {this.Name} is under attack!");
        this.UnderAttack?.Invoke();
    }
}