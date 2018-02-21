using System;

public class StartUp
{
    private static void Main()
    {
        while (true)
        {
            try
            {
                GetAnimal(out Animal animal);
                if (animal == null) return;
                Console.WriteLine(animal);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
    }

    private static void GetAnimal(out Animal animal)
    {
        animal = null;

        string animalsType = Console.ReadLine();
        if (animalsType == "Beast!") return;

        string[] tokens = Console.ReadLine().Split(" ");
        string name = tokens[0];
        int age = int.Parse(tokens[1]);
        string gender = tokens[2];

        switch (animalsType)
        {
            case "Dog":
                animal = new Dog(name, age, gender);
                break;

            case "Frog":
                animal = new Frog(name, age, gender);
                break;

            case "Cat":
                animal = new Cat(name, age, gender);
                break;

            case "Kitten":
                animal = new Kitten(name, age);
                break;

            case "Tomcat":
                animal = new Tomcat(name, age);
                break;

            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}