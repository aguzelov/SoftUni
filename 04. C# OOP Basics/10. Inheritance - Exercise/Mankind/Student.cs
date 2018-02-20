using System;

public class Student : Human
{
    private string facultyNumber;

    private string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            if (!ValidateFacultyNumber(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    private bool ValidateFacultyNumber(string value)
    {
        if (value.Length < 5 || value.Length > 10)
        {
            return false;
        }

        foreach (var c in value)
        {
            if (!char.IsLetterOrDigit(c)) return false;
        }

        return true;
    }

    public override string ToString()
    {
        return base.ToString() +
               $"Faculty number: {this.FacultyNumber}{Environment.NewLine}";
    }
}