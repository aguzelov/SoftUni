using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
    class AverageGrades
    {
        static List<Student> students = new List<Student>();

        static void PrintStudentsAverageGrade()
        {
            var ordered = students.OrderBy(x => x.Name).ThenByDescending(x => x.Average).ToList();
            foreach (Student student in ordered)
            {
                if (student.Average >= 5.00)
                {
                    Console.WriteLine($"{student.Name} -> {string.Format("{0:0.00}", student.Average)}");
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                                        .Split(' ')
                                        .Where(p => !string.IsNullOrWhiteSpace(p))
                                        .ToArray();

                string name = input[0];
                double[] grades = input.Skip(1).ToArray().Select(double.Parse).ToArray();

                students.Add(new Student(name, grades));

            }

            PrintStudentsAverageGrade();
        }
    }

    class Student
    {
        private string name;
        private List<double> grades = new List<double>();
        private double average;

        public Student(string name, double[] grades)
        {
            this.name = name;

            AddGrade(grades);
        }

        public string Name { get => name; set => name = value; }
        public double Average { get => average; set => average = value; }
        public void AddGrade(double[] grade)
        {
            grades.AddRange(grade);

            AddToAverage();
        }

        private void AddToAverage()
        {
            average = grades.Average();
        }

    }
}
