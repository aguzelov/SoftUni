public class Hen : Bird
{
    public Hen(string animalName, double animalWeight, double wingSize)
        : base(animalName, animalWeight, wingSize)
    {
    }

    public override void Eat(Food food)
    {
        base.FoodEaten += food.Quantity;
        base.AnimalWeight += IncreaseWeightBy(food.Quantity);
    }

    private double IncreaseWeightBy(int foodQuantity)
    {
        double result = WeightIncreaseByAnimal.Hen * foodQuantity;
        return result;
    }

    public override void MakeSound()
    {
        System.Console.WriteLine("Cluck");
    }
}