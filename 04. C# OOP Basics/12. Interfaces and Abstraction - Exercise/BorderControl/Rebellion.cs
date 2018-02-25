public abstract class Rebellion : IBirthdate
{
    private string name;
    private string birthdate;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public virtual string Birthdate
    {
        get
        {
            return this.birthdate;
        }
        set
        {
            this.birthdate = value;
        }
    }

    public Rebellion(string name)
    {
        this.Name = name;
    }
}