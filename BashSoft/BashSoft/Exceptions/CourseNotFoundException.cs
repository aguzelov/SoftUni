using System;

namespace BashSoft.Exceptions
{
    internal class CourseNotFoundException : Exception
    {
        private const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";

        public CourseNotFoundException()
            : base(NotEnrolledInCourse)
        {
        }

        public CourseNotFoundException(string message)
            : base(message)
        {
        }
    }
}