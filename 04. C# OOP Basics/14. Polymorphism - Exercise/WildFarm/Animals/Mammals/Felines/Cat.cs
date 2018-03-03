public class Cat : Feline
{
    public Cat(string animalName, double animalWeight, string livingRegion, string breed)
        : base(animalName, animalWeight, livingRegion, breed)
    {
    }

    public override void Eat(Food food)
    {
        if (!(food is Meat) && !(food is Vegetable))
        {
            throw new System.ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        base.FoodEaten += food.Quantity;
        base.AnimalWeight += IncreaseWeightBy(food.Quantity);
    }

    private double IncreaseWeightBy(int foodQuantity)
    {
        double result = WeightIncreaseByAnimal.Cat * foodQuantity;
        return result;
    }

    public override void MakeSound()
    {
        System.Console.WriteLine("Meow");
    }
}