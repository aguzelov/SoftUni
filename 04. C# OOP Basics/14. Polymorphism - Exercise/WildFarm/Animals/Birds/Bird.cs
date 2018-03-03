public abstract class Bird : Animal
{
    private double wingSize;

    protected Bird(string animalName, double animalWeight, double wingSize) : base(animalName, animalWeight)
    {
        WingSize = wingSize;
    }

    public double WingSize
    {
        get
        {
            return this.wingSize;
        }
        protected set
        {
            this.wingSize = value;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{base.AnimalName}, {this.WingSize}, {base.AnimalWeight}, {base.FoodEaten}]";
    }
}