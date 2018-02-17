using System;
using System.Collections.Generic;
using System.Linq;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.repo = new Dictionary<string, Student>();
    }

    public void ParseCommand(string stringArgs)
    {
        string[] args = stringArgs.Split();
        string command = args[0];

        if (command == "Create")
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);

            CreateEntity(name, age, grade);
        }
        else if (command == "Show")
        {
            var name = args[1];

            ShowEntity(name);
        }
    }

    private void ShowEntity(string name)
    {
        if (repo.ContainsKey(name))
        {
            var student = repo[name];
            string view = CreateView(student.Name, student.Age, student.Grade);

            Console.WriteLine(view);
        }
    }

    private static string CreateView(string name, int age, double grade)
    {
        string view = $"{name} is {age} years old.";

        if (grade >= 5.00)
        {
            view += " Excellent student.";
        }
        else if (grade < 5.00 && grade >= 3.50)
        {
            view += " Average student.";
        }
        else
        {
            view += " Very nice person.";
        }

        return view;
    }

    private void CreateEntity(string name, int age, double grade)
    {
        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            repo[name] = student;
        }
    }
}