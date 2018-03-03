public class Mouse : Mammal
{
    public Mouse(string animalName, double animalWeight, string livingRegion) : base(animalName, animalWeight, livingRegion)
    {
    }

    public override void Eat(Food food)
    {
        if (!(food is Fruit) && !(food is Vegetable))
        {
            throw new System.ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        base.FoodEaten += food.Quantity;
        base.AnimalWeight += IncreaseWeightBy(food.Quantity);
    }

    private double IncreaseWeightBy(int foodQuantity)
    {
        double result = WeightIncreaseByAnimal.Mouse * foodQuantity;
        return result;
    }

    public override void MakeSound()
    {
        System.Console.WriteLine("Squeak");
    }
}