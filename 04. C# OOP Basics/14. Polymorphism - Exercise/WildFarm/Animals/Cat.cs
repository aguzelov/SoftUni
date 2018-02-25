public class Cat : Felime
{
    private string breed;

    public string Breed { get => breed; set => breed = value; }

    public Cat(string animalType, string animalName, double animalWeight, string livingRegion, string breed) : base(animalType, animalName, animalWeight, livingRegion)
    {
        Breed = breed;
    }

    public override void Eat(Food food)
    {
        base.FoodEaten += food.Quntity;
    }

    public override void MakeSound()
    {
        System.Console.WriteLine("Meowwww");
    }

    public override string ToString()
    {
        return $"{base.AnimalType}[{base.AnimalName}, {this.Breed}, {base.AnimalWeight}, {this.LivingRegion}, {base.FoodEaten}]";
    }
}