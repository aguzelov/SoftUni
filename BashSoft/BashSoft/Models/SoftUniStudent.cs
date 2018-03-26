using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft.Models
{
    public class SoftUniStudent : IStudent
    {
        private string userName;
        private Dictionary<string, ICourse> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public string UserName
        {
            get { return this.userName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.userName = value;
            }
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses
        {
            get { return enrolledCourses; }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return marksByCourseName; }
        }

        public SoftUniStudent(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public void EnrollInCourse(ICourse softUniCourse)
        {
            if (this.EnrolledCourses.ContainsKey(softUniCourse.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, softUniCourse.Name);
            }

            this.enrolledCourses.Add(softUniCourse.Name, softUniCourse);
        }

        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam =
                scores.Sum() / (double)(SoftUniCourse.NumberOfTasksOnExam * SoftUniCourse.MaxScoreOnExamTask);
            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }

        public int CompareTo(IStudent other) => this.UserName.CompareTo(other.UserName);

        public override string ToString() => this.UserName;
    }
}