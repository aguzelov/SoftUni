using System;
using System.Collections.Generic;
using System.Text;
using Twitter.Contracts;

namespace Twitter.IO
{
    public class ConsoleWriter : IWriter
    {
        public ConsoleWriter()
        {
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}