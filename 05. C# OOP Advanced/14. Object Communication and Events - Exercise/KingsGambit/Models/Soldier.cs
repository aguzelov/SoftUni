public abstract class Soldier : INamed
{
    public Soldier(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public abstract void KingUnderAttack();
}