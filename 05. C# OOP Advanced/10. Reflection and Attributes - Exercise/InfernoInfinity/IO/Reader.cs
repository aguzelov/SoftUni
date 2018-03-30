using P09_InfernoInfinity.Contracts;
using System;

namespace P09_InfernoInfinity.IO
{
    public class Reader : IReader
    {
        public Reader()
        {
        }

        public string ReadLine()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}