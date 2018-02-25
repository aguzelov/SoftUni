public static class AnimalFactory
{
    public static Animal GetAnimal(string[] animalParam)
    {
        string type = animalParam[0];
        string name = animalParam[1];
        double weight = double.Parse(animalParam[2]);
        string region = animalParam[3];

        switch (type)
        {
            case "Mouse":
                return new Mouse(type, name, weight, region);

            case "Cat":
                string breed = animalParam[4];
                return new Cat(type, name, weight, region, breed);

            case "Tiger":
                return new Tiger(type, name, weight, region);

            case "Zebra":
                return new Zebra(type, name, weight, region);

            default:
                throw new System.ArgumentException();
        }
    }
}