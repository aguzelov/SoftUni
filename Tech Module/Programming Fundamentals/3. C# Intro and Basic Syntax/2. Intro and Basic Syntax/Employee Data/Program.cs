using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Data
{
    class Program
    {
        static string name;
        static int age;
        static int id;
        static double salary;
        Program(string name, int age, int id, double salary)
        {
            Program.name = name;
            Program.age = age;
            Program.id = id;
            Program.salary = salary;
        }
        static void Print()
        {
            Console.WriteLine("Name: "+ name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Employee ID: "+id.ToString().PadLeft(8, '0'));
            Console.WriteLine("Salary: " + salary.ToString("0.00"));
        }
        static void Main(string[] args)
        {
            Program employee = new Program(Console.ReadLine(), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Print();
        }    
    }
}
