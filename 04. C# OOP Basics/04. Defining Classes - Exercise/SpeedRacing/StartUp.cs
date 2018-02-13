using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            string model = input[0];
            double fuelAmount = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);

            if (!cars.ContainsKey(model))
            {
                cars.Add(model, new Car(model, fuelAmount, fuelConsumption));
            }
        }

        string command = String.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] moveParam = command.Split();

            string model = moveParam[1];
            double amountOfKm = double.Parse(moveParam[2]);

            cars[model].Move(amountOfKm);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.Value.ToString());
        }
    }
}