public class Citizen : Person
{
    private string id;

    private string birthdate;

    public string Id
    {
        get
        {
            return this.id;
        }
        private set
        {
            this.id = value;
        }
    }

    public string Birthdate
    {
        get
        {
            return this.birthdate;
        }
        private set
        {
            this.birthdate = value;
        }
    }

    public Citizen(string name, int age, string id, string birthdate) :
        base(name, age)
    {
        Id = id;
        Birthdate = birthdate;
    }

    public override void BuyFood()
    {
        TotalFood += 10;
        Food += 10;
    }
}