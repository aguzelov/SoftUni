using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            List<Tire> tires = new List<Tire>();
            for(int tireIndex = 5; tireIndex < parameters.Length; tireIndex += 2)
            {
                double tirePressure = double.Parse(parameters[tireIndex]);
                int tireAge = int.Parse(parameters[tireIndex + 1]);

                tires.Add(new Tire(tirePressure, tireAge));
            }
            
            cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tires));
        }

        string command = Console.ReadLine();
        if (command == "fragile")
        {
            List<string> fragile = cars
                .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fragile));
        }
        else
        {
            List<string> flamable = cars
                .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, flamable));
        }
    }
}