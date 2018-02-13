using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] carParam = Console.ReadLine().Split();

            string model = carParam[0];
            int engineSpeed = int.Parse(carParam[1]);
            int enginePower = int.Parse(carParam[2]);
            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(carParam[3]);
            string cargoType = carParam[4];

            Cargo cargo = new Cargo(cargoWeight, cargoType);

            List<Tire> tires = new List<Tire>();
            for (int j = 0; j < 8; j += 2)
            {
                double tirePressure = double.Parse(carParam[5 + j]);
                int tireAge = int.Parse(carParam[6 + j]);
                Tire tire = new Tire(tirePressure, tireAge);
                tires.Add(tire);
            }

            cars.Add(new Car(model, engine, cargo, tires));
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            foreach (var car in cars.Where(c => c.Cargo.CargoType == command && 
                                                c.Tires.Any(t => t.TirePressure < 1.0)))
            {

                Console.WriteLine($"{car.Model}");

            }

        }
        else if (command == "flamable")
        {
            foreach (var car in cars.Where(c => c.Cargo.CargoType == command && c.Engine.EnginePower > 250))
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }
}