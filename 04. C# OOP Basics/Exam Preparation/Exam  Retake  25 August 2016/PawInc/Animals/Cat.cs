public class Cat : IAnimal
{
    private string name;
    private int age;
    private int intelligence;
    private string status;

    public Cat(string name, int age, int intelligence)
    {
        Name = name;
        Age = age;
        Intelligence = intelligence;
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

    public int Intelligence
    {
        get
        {
            return this.intelligence;
        }
        private set
        {
            this.intelligence = value;
        }
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}