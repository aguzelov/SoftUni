public abstract class Feline : Mammal
{
    private string breed;

    protected Feline(string animalName, double animalWeight, string livingRegion, string breed)
        : base(animalName, animalWeight, livingRegion)
    {
        Breed = breed;
    }

    public string Breed
    {
        get
        {
            return this.breed;
        }
        private set
        {
            this.breed = value;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{base.AnimalName}, {this.Breed}, {base.AnimalWeight}, {base.LivingRegion}, {base.FoodEaten}]";
    }
}