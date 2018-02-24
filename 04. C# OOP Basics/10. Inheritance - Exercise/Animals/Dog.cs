internal class Dog : Animal
{
    private string sound;

    public Dog(string name, int age, string gender) : base(name, age, gender)
    {
        this.sound = "Woof!";
    }

    protected override string ProduceSound()
    {
        return this.sound;
    }
}