using System;

namespace BashSoft.Exceptions
{
    public class InvalidTakeQueryParamterException : Exception
    {
        private const string InvalidTakeQuantityParameter = "The take quantity expected does not match the format wanted!";

        public InvalidTakeQueryParamterException() : base(InvalidTakeQuantityParameter)
        {
        }

        public InvalidTakeQueryParamterException(string message) : base(message)
        {
        }
    }
}