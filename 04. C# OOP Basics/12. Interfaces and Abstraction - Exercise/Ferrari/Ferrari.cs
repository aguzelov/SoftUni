public class Ferrari : ICar
{
    private string driver;
    private string model;

    public Ferrari(string driver)
    {
        this.Model = "488-Spider";
        this.Driver = driver;
    }

    public string Driver
    {
        get { return this.driver; }
        set { this.driver = value; }
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            this.model = value;
        }
    }

    public string PushBreake()
    {
        return "Brakes!";
    }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{Model}/{PushBreake()}/{PushGas()}/{Driver}";
    }
}