using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AverageGrades
{
    class AverageGrades
    {
        private static readonly string inputFileName = "input.txt";

        private static readonly string outputFileName = "output.txt";
        
        static List<Student> students = new List<Student>();

        static void PrintStudentsAverageGrade()
        {
            var ordered = students.OrderBy(x => x.Name).ThenByDescending(x => x.Average).ToList();
            foreach (Student student in ordered)
            {
                if (student.Average >= 5.00)
                {
                    WriteToFile($"{student.Name} -> {student.Average:0.00}");
                }
            }
            WriteToFile(String.Empty);
        }

        static void WriteToFile(string text)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, true))
            {
                writer.WriteLine(text);
            }
        }

        static void CleanOutputFile()
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, false))
            {
                writer.Write(String.Empty);
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(inputFileName);

            int n = int.Parse(lines[0]);

            for (int i = 1; i < n + 1; i++)
            {
                string[] input = lines[i]
                                 .Split(' ')
                                 .Where(p => !string.IsNullOrWhiteSpace(p))
                                 .ToArray();

                string name = input[0];
                double[] grades = input.Skip(1).ToArray().Select(double.Parse).ToArray();

                students.Add(new Student(name, grades));

            }

            CleanOutputFile();

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
