using System;

public class Topping
{
    private string type;
    private int weight;
    private double calories;

    private string Type
    {
        set
        {
            if (string.IsNullOrEmpty(value) ||
                (value.ToLower() != "Meat".ToLower() &&
                value.ToLower() != "Veggies".ToLower() &&
                value.ToLower() != "Cheese".ToLower() &&
                value.ToLower() != "Sauce".ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.type = value;
        }
    }

    private int Weight
    {
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double Calories
    {
        get
        {
            return this.calories;
        }
    }

    public Topping(string type, int weight)
    {
        Type = type;
        Weight = weight;
        CalculateCalories();
    }

    private void CalculateCalories()
    {
        GetToppingType(out double toppingModifier);
        this.calories = (2.0 * this.weight) * toppingModifier;
    }

    private void GetToppingType(out double toppingModifier)
    {
        toppingModifier = 0;
        switch (this.type.ToLower())
        {
            case "meat":
                toppingModifier = ToppingType.Meat;
                break;

            case "veggies":
                toppingModifier = ToppingType.Veggies;
                break;

            case "cheese":
                toppingModifier = ToppingType.Cheese;
                break;

            case "sauce":
                toppingModifier = ToppingType.Sauce;
                break;
        }
    }
}