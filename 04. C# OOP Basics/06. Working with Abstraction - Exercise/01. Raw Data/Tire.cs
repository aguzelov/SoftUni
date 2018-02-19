class Tire
{
    private double pressure;

    public double Pressure
    {
        get { return this.pressure; }
        set { this.pressure = value; }
    }

    private int age;

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Tire(double pressure, int age)
    {
        this.pressure = pressure;
        this.age = age;
    }

    public Tire()
    {
    }
}
