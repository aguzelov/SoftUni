internal class Tomcat : Cat
{
    private string sound;

    public Tomcat(string name, int age) : base(name, age, "Male")
    {
        this.sound = "Give me one million b***h";
    }

    protected override string ProduceSound()
    {
        return this.sound;
    }
}