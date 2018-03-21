using P03.Detail_Printer.Interfaces;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    internal class Program
    {
        private static void Main()
        {
            List<string> documents = new List<string>()
            {
                "test document 1",
                "test document 2",
                "test document 3",
                "test document 4",
            };

            Employee employee1 = new Employee("Pencho");
            Employee employee2 = new Employee("Pancho");
            Employee employee3 = new Employee("Pincho");
            Manager manager1 = new Manager("Mincho", documents);
            Manager manager2 = new Manager("Mancho", documents);
            Manager manager3 = new Manager("Muncho", documents);

            List<IPrintable> employees = new List<IPrintable>()
            {
                employee1,
                employee2,
                employee3,
                manager1,
                manager2,
                manager3
            };

            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}