public class Dog : IAnimal
{
    private string name;
    private int age;
    private int commands;
    private string status;

    public Dog(string name, int age, int commands)
    {
        Name = name;
        Age = age;
        Commands = commands;
        CleansingStatus = "UNCLEANSED";
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        private set
        {
            this.age = value;
        }
    }

    public string CleansingStatus
    {
        get
        {
            return this.status;
        }
        set
        {
            this.status = value;
        }
    }

    public int Commands
    {
        get
        {
            return this.commands;
        }
        private set
        {
            this.commands = value;
        }
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}