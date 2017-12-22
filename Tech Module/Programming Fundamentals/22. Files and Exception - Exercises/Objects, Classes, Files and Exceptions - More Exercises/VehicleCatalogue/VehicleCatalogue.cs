using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue
{
    class VehicleCatalogue
    {
        static List<Car> carCatalogue = new List<Car>();

        static List<Truck> truckCatalogue = new List<Truck>();

        static void PrintAverageHp()
        {
            double carAverageHp = 0.00;
            double truckAverageHp = 0.00;


            try
            {
                carAverageHp = carCatalogue.Average(x => x.Hp);

                Console.WriteLine($"{Car.Type}s have average horsepower of: {string.Format("{0:0.00}", carAverageHp)}.");


            }
            catch
            {
                Console.WriteLine($"{Car.Type}s have average horsepower of: {string.Format("{0:0.00}", carAverageHp)}.");

            }

            try
            {
                truckAverageHp = truckCatalogue.Average(x => x.Hp);
                Console.WriteLine($"{Truck.Type}s have average horsepower of: {string.Format("{0:0.00}", truckAverageHp)}.");
            }
            catch
            {
                Console.WriteLine($"{Truck.Type}s have average horsepower of: {string.Format("{0:0.00}", truckAverageHp)}.");
            }
        }

        static bool SetInput()
        {
            string input = Console.ReadLine();

            if (input == "End")
            {
                return false;
            }

            string[] vehicleInfo = input.Split(' ').ToArray();

            string type = vehicleInfo[0];
            string model = vehicleInfo[1];
            string color = vehicleInfo[2];
            int hp = int.Parse(vehicleInfo[3]);

            if (type.ToLower() == "car")
            {
                carCatalogue.Add(new Car(model, color, hp));
            }
            else
            {
                truckCatalogue.Add(new Truck(model, color, hp));
            }

            return true;
        }

        static bool TakeModels()
        {
            string input = Console.ReadLine();

            if (input == "Close the Catalogue")
            {
                PrintAverageHp();
                return false;
            }

            if (carCatalogue.Any(x => x.Model == input))
            {
                Car car = carCatalogue.Find(x => x.Model == input);
                car.PrintInfo();
            }
            else
            {
                Truck truck = truckCatalogue.Find(x => x.Model == input);
                truck.PrintInfo();
            }

            return true;
        }

        static void Main(string[] args)
        {
            while (SetInput()) { }

            while (TakeModels()) { }


        }
    }

    class Vehicle
    {
        private string model;
        private string color;
        private int hp;

        public Vehicle(string model, string color, int hp)
        {
            this.model = model;
            this.color = color;
            this.hp = hp;
        }

        public string Model { get => model; set => model = value; }
        public string Color { get => color; set => color = value; }
        public int Hp { get => hp; set => hp = value; }
    }

    class Car : Vehicle
    {
        private static string type = "Car";

        public Car(string model, string color, int hp) : base(model, color, hp)
        {
        }

        public static string Type { get => type; set => type = value; }

        public void PrintInfo()
        {
            Console.WriteLine($"Type: {type}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Horsepower: {Hp}");
        }
    }

    class Truck : Vehicle
    {
        private static string type = "Truck";

        public Truck(string model, string color, int hp) : base(model, color, hp)
        {
        }

        public static string Type { get => type; set => type = value; }

        public void PrintInfo()
        {
            Console.WriteLine($"Type: {type}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Horsepower: {Hp}");
        }
    }
}
