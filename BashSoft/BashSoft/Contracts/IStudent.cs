using System;
using System.Collections.Generic;

namespace BashSoft.Contracts
{
    public interface IStudent : IComparable<IStudent>
    {
        string UserName { get; }

        IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }

        IReadOnlyDictionary<string, double> MarksByCourseName { get; }

        void EnrollInCourse(ICourse softUniCourse);

        void SetMarksInCourse(string courseName, params int[] scores);
    }
}