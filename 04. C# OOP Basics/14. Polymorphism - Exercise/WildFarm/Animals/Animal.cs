public abstract class Animal
{
    private string animalName;
    private string animalType;
    private double animalWeight;
    private int foodEaten;

    public string AnimalName { get => animalName; set => animalName = value; }
    public string AnimalType { get => animalType; set => animalType = value; }
    public double AnimalWeight { get => animalWeight; set => animalWeight = value; }
    public int FoodEaten { get => foodEaten; set => foodEaten = value; }

    protected Animal(string animalType, string animalName, double animalWeight)
    {
        AnimalName = animalName;
        AnimalType = animalType;
        AnimalWeight = animalWeight;
        FoodEaten = foodEaten;
    }

    public abstract void MakeSound();

    public abstract void Eat(Food food);
}