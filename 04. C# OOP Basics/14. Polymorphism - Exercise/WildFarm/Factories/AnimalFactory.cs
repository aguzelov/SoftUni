public static class AnimalFactory
{
    public static Animal GetAnimal(string[] animalParam)
    {
        string type = animalParam[0];
        string name = animalParam[1];
        double weight = double.Parse(animalParam[2]);

        switch (type)
        {
            case "Owl":
                double wingSize = double.Parse(animalParam[3]);
                return new Owl(name, weight, wingSize);

            case "Hen":
                wingSize = double.Parse(animalParam[3]);
                return new Hen(name, weight, wingSize);

            case "Mouse":
                string livingRegion = animalParam[3];
                return new Mouse(name, weight, livingRegion);

            case "Dog":
                livingRegion = animalParam[3];
                return new Dog(name, weight, livingRegion);

            case "Cat":
                livingRegion = animalParam[3];
                string breed = animalParam[4];
                return new Cat(name, weight, livingRegion, breed);

            case "Tiger":
                livingRegion = animalParam[3];
                breed = animalParam[4];
                return new Tiger(name, weight, livingRegion, breed);

            default:
                throw new System.ArgumentException();
        }
    }
}