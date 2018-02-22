﻿using System;

namespace BashSoft.Exceptions
{
    internal class InvalidStringException : Exception
    {
        private const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!";

        public InvalidStringException() : base(NullOrEmptyValue)
        {
        }

        public InvalidStringException(string message) : base(message)
        {
        }
    }
}