using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        Dictionary<string, List<Employee>> employeeByDepartment = new Dictionary<string, List<Employee>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split();

            string name = input[0];
            double salary = double.Parse(input[1]);
            string position = input[2];
            string department = input[3];

            if (!employeeByDepartment.ContainsKey(department))
            {
                employeeByDepartment.Add(department, new List<Employee>());
            }

            if (input.Length == 4)
            {
                employeeByDepartment[department].Add(new Employee(name,salary,position, department));
            }else if (input.Length == 5)
            {
                if (int.TryParse(input[4], out int age))
                {
                    employeeByDepartment[department].Add(new Employee(name, salary, position, department, age));
                }
                else
                {
                    string email = input[4];
                    employeeByDepartment[department].Add(new Employee(name, salary, position, department, email));
                }
            }
            else
            {
                string email = input[4];
                int age = int.Parse(input[5]);
                employeeByDepartment[department].Add(new Employee(name, salary, position, department, email,age));
            }
        }

        double maxSalary = double.MinValue;
        string departmentWithMaxAverageSalary = String.Empty;
        foreach (var department in employeeByDepartment)
        {
            double averageSalary = department.Value.Sum(e => e.Salary);
            if (averageSalary > maxSalary)
            {
                maxSalary = averageSalary;
                departmentWithMaxAverageSalary = department.Key;
            }
        }

        List<Employee> maxAverageSalaryEmployees = employeeByDepartment[departmentWithMaxAverageSalary];

        Console.WriteLine($"Highest Average Salary: {departmentWithMaxAverageSalary}");
        foreach (var maxAverageSalaryEmployee in maxAverageSalaryEmployees.OrderByDescending(e => e.Salary).ToList())
        {
            Console.WriteLine(maxAverageSalaryEmployee.ToString());
        }
    }
}
