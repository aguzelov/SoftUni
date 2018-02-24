public class Citizen : Rebellion, ICitizen
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Citizen(string name, int age, string id)
        : base(id)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return Id;
    }
}