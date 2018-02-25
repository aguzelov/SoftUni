using System;

public class StartUp
{
    private static void Main()
    {
        Vehicle[] vehicles = new Vehicle[3];
        for (int i = 0; i < 3; i++)
        {
            vehicles[i] = InitVehicle();
        }

        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            string command = tokens[0];
            string type = tokens[1];
            double param = double.Parse(tokens[2]);

            if (type == "Car")
            {
                ExecuteCommand(vehicles[0], command, param);
            }
            else if (type == "Truck")
            {
                ExecuteCommand(vehicles[1], command, param);
            }
            else if (type == "Bus")
            {
                ExecuteCommand(vehicles[2], command, param);
            }
        }

        foreach (Vehicle vehicle in vehicles)
        {
            Writer.WriteLine(vehicle.ToString());
        }
    }

    private static void ExecuteCommand(Vehicle vehicle, string command, double param)
    {
        switch (command)
        {
            case "Drive":
                vehicle.AirConditioner = true;
                vehicle.Drive(param);
                break;

            case "DriveEmpty":
                vehicle.AirConditioner = false;
                vehicle.Drive(param);
                break;

            case "Refuel":
                vehicle.Refuel(param);
                break;
        }
    }

    private static Vehicle InitVehicle()
    {
        string[] tokens = Console.ReadLine().Split();
        string type = tokens[0];
        double quantity = double.Parse(tokens[1]);
        double consumption = double.Parse(tokens[2]);
        double capacity = double.Parse(tokens[3]);

        switch (type)
        {
            case "Car":
                return new Car(type, quantity, consumption, capacity);

            case "Truck":
                return new Truck(type, quantity, consumption, capacity);

            case "Bus":
                return new Bus(type, quantity, consumption, capacity);
        }
        return null;
    }
}