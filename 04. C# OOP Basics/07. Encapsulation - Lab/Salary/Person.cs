using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public decimal Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        this.age = age;
        this.salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (age < 30)
        {
            percentage = percentage / 200;
        }
        else
        {
            percentage = percentage / 100;
        }

        this.salary += (this.salary * percentage);
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} receives {this.salary:f2} leva.";
    }
}