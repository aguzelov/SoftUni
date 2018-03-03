public abstract class Animal
{
    private string animalName;
    private double animalWeight;
    private int foodEaten;

    public string AnimalName { get => animalName; set => animalName = value; }
    public double AnimalWeight { get => animalWeight; set => animalWeight = value; }
    public int FoodEaten { get => foodEaten; set => foodEaten = value; }

    protected Animal(string animalName, double animalWeight)
    {
        AnimalName = animalName;
        AnimalWeight = animalWeight;
        FoodEaten = 0;
    }

    public abstract void MakeSound();

    public abstract void Eat(Food food);
}