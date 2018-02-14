using System;

public class Company
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public Company()
    {
        Name = string.Empty;
        Department = string.Empty;
   
    }

    public Company(string name, string department, decimal salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }

    public override string ToString()
    {
        if(Name == string.Empty && Department == string.Empty)
        {
            return string.Empty;
        }
        return $"{Name} {Department} {Salary:F2}";
    }
}