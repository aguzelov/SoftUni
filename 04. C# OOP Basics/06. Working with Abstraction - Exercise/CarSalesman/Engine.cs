using System;

public class Engine
{
    public string Model { get; set; }
    public double Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }
    
    public Engine(string model, double power)
    {
        Model = model;
        Power = power;
        Displacement = "n/a";
        Efficiency = "n/a";
    }

    public Engine(string model, double power, string optional) : this(model, power)
    {
        if (double.TryParse(optional, out double displacement))
        {
            Displacement = displacement.ToString();
        }
        else
        {
            Efficiency = optional;
        }
    }
    
    public Engine(string model, double power, string displacement, string efficiency) : this(model, power)
    {
        Displacement = displacement;
        Efficiency = efficiency;
    }

    public override string ToString()
    {
        return $"    Displacement: {Displacement}{Environment.NewLine}" +
               $"    Efficiency: {Efficiency}{Environment.NewLine}";
    }
}