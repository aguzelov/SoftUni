using System.Collections.Generic;

class Car
{
    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, List<Tire> tires) : this()
    {
        this.model = model;
        this.Engine.EngineSpeed = engineSpeed;
        this.Engine.EnginePower = enginePower;
        this.Cargo.CargoWeight = cargoWeight;
        this.Cargo.CargoType = cargoType;
        this.Tires = tires;
    }

    public Car()
    {
        this.Engine = new Engine();
        this.Cargo = new Cargo();
        this.Tires = new List<Tire>();
    }

    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Engine Engine {
        get { return this.engine; }
        set { this.engine = value; }
    }
    public Cargo Cargo {
        get { return this.cargo; }
        set { this.cargo = value; }
    }
    public List<Tire> Tires {
        get { return this.tires; }
        set { this.tires = value; }
    }
}