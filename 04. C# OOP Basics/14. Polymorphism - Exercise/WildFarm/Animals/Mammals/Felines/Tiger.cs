public class Tiger : Feline
{
    public Tiger(string animalName, double animalWeight, string livingRegion, string breed)
        : base(animalName, animalWeight, livingRegion, breed)
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
        double result = WeightIncreaseByAnimal.Tiger * foodQuantity;
        return result;
    }

    public override void MakeSound()
    {
        System.Console.WriteLine("ROAR!!!");
    }
}