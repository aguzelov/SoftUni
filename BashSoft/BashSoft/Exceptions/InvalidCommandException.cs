using System;

namespace BashSoft.Exceptions
{
    internal class InvalidCommandException : Exception
    {
        private const string InvalidCommand = "The command '{0}' is invalid";

        public InvalidCommandException(string command)
            : base(string.Format(InvalidCommand, command))
        {
        }
    }
}