using System;

public abstract class Animal
{
    protected string name;
    protected int age;
    protected string gender;

    protected string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.name = value;
        }
    }

    protected int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0 || value > int.MaxValue)
            {
                throw new ArgumentException("Invalid input!");
            }

            this.age = value;
        }
    }

    protected string Gender
    {
        get
        {
            return this.gender;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            if (value != "Male" && value != "Female")
            {
                throw new ArgumentException("Invalid input!");
            }

            this.gender = value;
        }
    }

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    protected abstract string ProduceSound();

    public override string ToString()
    {
        return $"{this.GetType().Name}{Environment.NewLine}" +
               $"{this.name} {this.age} {this.gender}{Environment.NewLine}" +
               $"{ProduceSound()}";
    }
}