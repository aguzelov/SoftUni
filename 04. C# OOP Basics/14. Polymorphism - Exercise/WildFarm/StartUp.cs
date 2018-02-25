using System;
using System.Collections.Generic;

public class StartUp
{
    private static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            Animal animal = null;
            Food food = null;
            try
            {
                animal = AnimalFactory.GetAnimal(input.Split());
                food = FoodFactory.GetFood(Console.ReadLine().Split());
            }
            catch (ArgumentException)
            {
                continue;
            }

            animal.MakeSound();

            try
            {
                animal.Eat(food);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(animal.ToString());
        }
    }
}