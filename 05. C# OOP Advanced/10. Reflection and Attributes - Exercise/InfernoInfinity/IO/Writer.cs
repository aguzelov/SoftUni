using P09_InfernoInfinity.Contracts;
using System;

namespace P09_InfernoInfinity.IO
{
    public class Writer : IWriter
    {
        public Writer()
        {
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}