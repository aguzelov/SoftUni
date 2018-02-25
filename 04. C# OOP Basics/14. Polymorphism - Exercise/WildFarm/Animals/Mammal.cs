public abstract class Mammal : Animal
{
    private string livingRegion;

    public string LivingRegion { get => livingRegion; set => livingRegion = value; }

    protected Mammal(string animalType, string animalName, double animalWeight, string livingRegion)
        : base(animalType, animalName, animalWeight)
    {
        LivingRegion = livingRegion;
    }

    public override string ToString()
    {
        return $"{base.AnimalType}[{base.AnimalName}, {base.AnimalWeight}, {this.LivingRegion}, {base.FoodEaten}]";
    }
}