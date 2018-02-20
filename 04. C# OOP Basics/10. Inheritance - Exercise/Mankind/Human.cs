using System;

public class Human
{
    private string firstName;
    private string lastName;

    protected string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }

            this.firstName = value;
        }
    }

    protected string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }

            this.lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}{Environment.NewLine}" +
               $"Last Name: {this.LastName}{Environment.NewLine}";
    }
}