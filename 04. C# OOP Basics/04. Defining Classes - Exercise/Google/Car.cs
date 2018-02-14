using System;

public class Car
{
    public string Model { get; set; }
    public int Speed { get; set; }

    public Car()
    {
    }

    public Car(string model, int speed)
    {
        Model = model;
        Speed = speed;
    }

    public override string ToString()
    {
        if (Model == string.Empty)
        {
            return string.Empty;
        }
        return $"{Model} {Speed}";
    }
}