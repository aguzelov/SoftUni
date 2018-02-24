public class Robot : Rebellion, IRobot
{
    public string Model { get; set; }

    public Robot(string model, string id)
        : base(id)
    {
        Model = model;
    }

    public override string ToString()
    {
        return Id;
    }
}