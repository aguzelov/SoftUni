using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        int numberOfEngines = int.Parse(Console.ReadLine());

        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < numberOfEngines; i++)
        {
            string[] engineParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = engineParams[0];
            double power = double.Parse(engineParams[1]);

            Engine engine = null;

            if (engineParams.Length == 4)
            {
                string displacement = engineParams[2];
                string efficiency = engineParams[3];
                engine = new Engine(model, power, displacement, efficiency);
            }
            else if (engineParams.Length == 3)
            {
                string optional = engineParams[2];

                engine = new Engine(model, power, optional);
            }
            else
            {
                engine = new Engine(model, power);
            }

            engines.Add(engine);
        }

        List<Car> cars = new List<Car>();

        int numbersOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numbersOfCars; i++)
        {
            string[] carParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = carParams[0];
            string engineModel = carParams[1];

            Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);
            
            Car car = null;

            if (carParams.Length == 3)
            {
                string optional = carParams[2];
                car = new Car(model, engine, optional);
            }
            else if (carParams.Length == 4)
            {
                string weight = carParams[2];
                string color = carParams[3];
                car = new Car(model, engine, weight, color);
            }
            else
            {
                car = new Car(model, engine);
            }
            
            cars.Add(car);
        }

        cars.ForEach(c => Console.WriteLine(c.ToString()));
    }
}