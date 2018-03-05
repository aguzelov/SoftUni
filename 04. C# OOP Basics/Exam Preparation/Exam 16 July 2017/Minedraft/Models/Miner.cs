public abstract class Miner : IId
{
    private string id;

    protected Miner(string id)
    {
        Id = id;
    }

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
}