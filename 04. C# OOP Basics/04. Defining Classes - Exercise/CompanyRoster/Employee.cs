public class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee(string name, double salary, string position, string department)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;

        Email = "n/a";
        Age = -1;
    }

    public Employee(string name, double salary, string position, string department, int age) : this(name, salary, position, department)
    {
        Age = age;
    }

    public Employee(string name, double salary, string position, string department, string email) : this(name, salary, position, department)
    {
        Email = email;
    }

    public Employee(string name, double salary, string position, string department, string email, int age) : this(name, salary, position, department)
    {
        Email = email;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} {Salary:F2} {Email} {Age}";
    }
}
