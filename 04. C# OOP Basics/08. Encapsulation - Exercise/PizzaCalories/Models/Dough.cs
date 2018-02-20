using System;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private int weight;
    private double calories;

    private string Type
    {
        set
        {
            if (string.IsNullOrEmpty(value) ||
                (value.ToLower() != "white" && value.ToLower() != "wholegrain"))
            {
                throw new ArgumentException($"Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    private string Technique
    {
        set
        {
            if (string.IsNullOrEmpty(value) ||
                (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade"))
            {
                throw new ArgumentException($"Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    private int Weight
    {
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
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

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        Type = flourType;
        Technique = bakingTechnique;
        Weight = weight;
        CalculateCalories();
    }

    private void CalculateCalories()
    {
        GetFlourModifier(out double flourModifier);
        GetBakingModifier(out double bakingModifier);

        this.calories = (2.0 * this.weight) * flourModifier * bakingModifier;
    }

    private void GetFlourModifier(out double flourModifier)
    {
        flourModifier = 0;
        switch (this.flourType.ToLower())
        {
            case "white":
                flourModifier = FlourType.White;
                break;

            case "wholegrain":
                flourModifier = FlourType.Wholegrain;
                break;
        }
    }

    private void GetBakingModifier(out double bakingModifier)
    {
        bakingModifier = 0;
        switch (this.bakingTechnique.ToLower())
        {
            case "crispy":
                bakingModifier = BakingTechnique.Crispy;
                break;

            case "chewy":
                bakingModifier = BakingTechnique.Chewy;
                break;

            case "homemade":
                bakingModifier = BakingTechnique.Homemade;
                break;
        }
    }
}