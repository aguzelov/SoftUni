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
        set
        {
            if (value < 460)
            {
                throw new ArgumentException($"Salary cannot be less than 460 leva!");
            }
            this.salary = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Age cannot be zero or a negative integer!");
            }
            this.age = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            if (value.Length < 3)
            {
                throw new ArgumentException($"Last name cannot contain fewer than 3 symbols!");
            }

            this.lastName = value;
        }
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            if (value.Length < 3)
            {
                throw new ArgumentException($"First name cannot contain fewer than 3 symbols!");
            }

            this.firstName = value;
        }
    }

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Age = age;
        Salary = salary;
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