public class Owl : Bird
{
    public Owl(string animalName, double animalWeight, double wingSize)
        : base(animalName, animalWeight, wingSize)
    {
    }

    public override void Eat(Food food)
    {
        if (!(food is Meat))
        {
            throw new System.ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        base.FoodEaten += food.Quantity;
        base.AnimalWeight += IncreaseWeightBy(food.Quantity);
    }

    private double IncreaseWeightBy(int foodQuantity)
    {
        double result = WeightIncreaseByAnimal.Owl * foodQuantity;
        return result;
    }

    public override void MakeSound()
    {
        System.Console.WriteLine("Hoot Hoot");
    }
}