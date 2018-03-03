public abstract class Mammal : Animal
{
    private string livingRegion;

    public string LivingRegion { get => livingRegion; set => livingRegion = value; }

    protected Mammal(string animalName, double animalWeight, string livingRegion)
        : base(animalName, animalWeight)
    {
        LivingRegion = livingRegion;
    }

    public override void Eat(Food food)
    {
        base.FoodEaten += food.Quantity;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{base.AnimalName}, {base.AnimalWeight}, {this.LivingRegion}, {base.FoodEaten}]";
    }
}