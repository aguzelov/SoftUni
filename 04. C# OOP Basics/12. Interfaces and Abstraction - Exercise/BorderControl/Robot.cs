public class Robot : Rebellion, IId
{
    private string id;

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

    public Robot(string model, string id)
        : base(model)
    {
        this.Id = id;
    }

    public override string ToString()
    {
        return Id;
    }
}