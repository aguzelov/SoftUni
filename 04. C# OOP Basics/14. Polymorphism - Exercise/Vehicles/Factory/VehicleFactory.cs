using System;

public static class VehicleFactory
{
    public static Vehicle GetVehicle(Func<string> reader)
    {
        string[] tokens = reader().Split();
        string type = tokens[0];
        double quantity = double.Parse(tokens[1]);
        double consumption = double.Parse(tokens[2]);
        double capacity = double.Parse(tokens[3]);

        switch (type)
        {
            case "Car":
                return new Car(quantity, consumption, capacity);

            case "Truck":
                return new Truck(quantity, consumption, capacity);

            case "Bus":
                return new Bus(quantity, consumption, capacity);
            default:
                throw new System.ArgumentException();
        }
    }
}
