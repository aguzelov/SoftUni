internal class Kitten : Cat
{
    private string sound;

    public Kitten(string name, int age) : base(name, age, "Female")
    {
        this.sound = "Miau";
    }

    protected override string ProduceSound()
    {
        return this.sound;
    }
}