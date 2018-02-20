using System;

public class StartUp
{
    private static void Main()
    {
        Student student = null;
        Worker worker = null;
        try
        {
            SetStudent(out student);
            SetWorker(out worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Console.WriteLine(student);
        Console.WriteLine(worker);
    }

    private static void SetWorker(out Worker worker)
    {
        string input = Console.ReadLine();
        string[] tokens = input.Split();
        string firstName = tokens[0];
        string lastName = tokens[1];
        decimal weekSalary = decimal.Parse(tokens[2]);
        decimal hoursPerDay = decimal.Parse(tokens[3]);
        worker = new Worker(firstName, lastName, weekSalary, hoursPerDay);
    }

    private static void SetStudent(out Student student)
    {
        string input = Console.ReadLine();
        string[] tokens = input.Split();
        string firstName = tokens[0];
        string lastName = tokens[1];
        string facultyNumber = tokens[2];
        student = new Student(firstName, lastName, facultyNumber);
    }
}