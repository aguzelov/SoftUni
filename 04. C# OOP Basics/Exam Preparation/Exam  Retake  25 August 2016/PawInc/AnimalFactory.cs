public static class AnimalFactory
{
    public static IAnimal CreateAnimal(string type, params string[] animalParams)
    {
        string name = animalParams[0];
        int age = int.Parse(animalParams[1]);
        switch (type)
        {
            case "Dog":
                int commands = int.Parse(animalParams[2]);
                return new Dog(name, age, commands);

            case "Cat":
                int intelligence = int.Parse(animalParams[2]);
                return new Cat(name, age, intelligence);

            default:
                throw new System.ArgumentOutOfRangeException(nameof(type), "Animal type must be Dog or Cat");
        }
    }
}