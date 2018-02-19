using System;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
        Weight = "n/a";
        Color = "n/a";
    }

    public Car(string model, Engine engine, string optional) : this(model, engine)
    {
        if (double.TryParse(optional, out double weight))
        {
            Weight = weight.ToString();
        }
        else
        {
            Color = optional;
        }
    }

    public Car(string model, Engine engine, string weight, string color) : this(model, engine)
    {
        Weight = weight;
        Color = color;
    }

    public override string ToString()
    {
        return $"{Model}:{Environment.NewLine}" +
               $"  {Engine.Model}:{Environment.NewLine}" +
               $"    Power: {Engine.Power}{Environment.NewLine}" +
               $"{Engine.ToString()}" +
               $"    Weight: {Weight}{Environment.NewLine}" +
               $"    Color: {Color}";
    }
}
