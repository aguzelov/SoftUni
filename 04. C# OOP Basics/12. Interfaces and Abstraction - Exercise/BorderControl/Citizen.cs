public class Citizen : Rebellion, ICitizen
{
    private int age;
    private string id;

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }

    public string Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }

    public override string Birthdate { get => base.Birthdate; set => base.Birthdate = value; }

    public Citizen(string name, int age, string id, string birthdate)
        : base(name)
    {
        Age = age;
        this.Birthdate = birthdate;
    }

    public override string ToString()
    {
        return Birthdate;
    }
}