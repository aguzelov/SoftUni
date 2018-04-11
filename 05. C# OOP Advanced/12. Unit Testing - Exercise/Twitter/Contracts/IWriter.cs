using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.Contracts
{
    public interface IWriter
    {
        void WriteMessage(string message);
    }
}