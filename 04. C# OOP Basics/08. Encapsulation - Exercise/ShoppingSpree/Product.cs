using System;

public class Product
{
    private string name;
    private decimal cost;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    public decimal Cost
    {
        get { return cost; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            cost = value;
        }
    }

    public Product()
    {
    }

    public Product(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"{name}";
    }
}