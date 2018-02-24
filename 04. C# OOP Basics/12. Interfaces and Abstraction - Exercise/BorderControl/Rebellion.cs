public abstract class Rebellion : IId
{
    public string Id { get; set; }

    public Rebellion(string id)
    {
        this.Id = id;
    }
}