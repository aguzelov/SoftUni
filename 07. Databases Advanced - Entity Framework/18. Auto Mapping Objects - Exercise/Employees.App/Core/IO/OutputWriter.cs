using Employees.App.Core.IO.Contracts;
using System;

namespace Employees.App.Core.IO
{
    public class OutputWriter : IOutputWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void Write(string line)
        {
            Console.Write(line);
        }
    }
}