using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;

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

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        this.age = age;
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} is {this.age} years old.";
    }
}