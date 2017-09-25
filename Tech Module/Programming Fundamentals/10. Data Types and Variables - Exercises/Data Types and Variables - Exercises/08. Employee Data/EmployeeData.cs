using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Employee_Data
{
    class EmployeeData
    {

        public static string FirstName;
        public static string LastName;
        public static int Age;
        public static char Gender;
        public static long ID;
        public static long UniqueEmployeeNumber;

        EmployeeData()
        {
            EmployeeData.FirstName = Console.ReadLine();
            EmployeeData.LastName = Console.ReadLine();
            EmployeeData.Age = int.Parse(Console.ReadLine());
            EmployeeData.Gender = char.Parse(Console.ReadLine());
            EmployeeData.ID = long.Parse(Console.ReadLine());
            EmployeeData.UniqueEmployeeNumber = long.Parse(Console.ReadLine());
            PrintEmployeeData();
        }
        static void PrintEmployeeData()
        {
            Console.WriteLine("First name: {0}", FirstName);
            Console.WriteLine("Last name: {0}", LastName);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Gender: {0}",Gender);
            Console.WriteLine("Personal ID: {0}", ID);
            Console.WriteLine("Unique Employee number: {0}", UniqueEmployeeNumber);
        }

        static void Main(string[] args)
        {
            new EmployeeData();
        }
    }
}
