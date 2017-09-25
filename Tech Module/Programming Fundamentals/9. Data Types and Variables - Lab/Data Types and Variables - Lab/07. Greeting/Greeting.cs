using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Greeting
{
    class Greeting
    {
        string FirstName;
        string LastName;
        int age;

        Greeting(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.age = age;
            PrintGreeting();
        }

        void PrintGreeting()
        {
            Console.WriteLine($"Hello, {this.FirstName} {this.LastName}. You are {this.age} years old.");
        }

        static void Main(string[] args)
        {
            new Greeting(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()));
        }
    }
}
