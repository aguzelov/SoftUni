using System;
using System.Collections.Generic;

namespace BashSoft.Models
{
    public class Course
    {
        private string name;
        private Dictionary<string, Student> studentsByName;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.name), ExceptionMessages.NullOrEmptyValue);
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsByName
        {
            get { return studentsByName; }
        }

        public const int NumberOfTasksOnExam = 5;
        public const double MaxScoreOnExamTask = 100;

        public Course(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public void EnrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey((student.UserName)))
            {
                throw  new ArgumentException(string.Format(
                    ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                    student.UserName, this.name));
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}
