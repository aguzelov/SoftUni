using System;
public class Gandalf
{
    private Mood mood;

    public Gandalf()
    {
        this.mood = new Mood();
    }

    public void EatFood(string food)
    {
        this.mood.AddHappiness(food);
    }

    public override string ToString()
    {
        return $"{this.mood.Happiness}{Environment.NewLine}" +
               $"{this.mood.MoodType}";
    }
}