public class Pet : Rebellion
{
    public override string Birthdate { get => base.Birthdate; set => base.Birthdate = value; }

    public Pet(string name, string birthdate) :
        base(name)
    {
        this.Birthdate = birthdate;
    }

    public override string ToString()
    {
        return Birthdate;
    }
}