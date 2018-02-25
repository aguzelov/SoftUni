public class Mouse : Mammal
{
    public Mouse(string animalType, string animalName, double animalWeight, string livingRegion) : base(animalType, animalName, animalWeight, livingRegion)
    {
    }

    public override void Eat(Food food)
    {
        if (!(food is Vegetable))
        {
            throw new System.ArgumentException($"{base.AnimalType}s are not eating that type of food!");
        }
        base.FoodEaten += food.Quntity;
    }

    public override void MakeSound()
    {
        System.Console.WriteLine("SQUEEEAAAK!");
    }
}