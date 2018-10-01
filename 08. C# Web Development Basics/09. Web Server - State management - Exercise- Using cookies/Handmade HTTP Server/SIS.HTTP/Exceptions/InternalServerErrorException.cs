using System;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string DefaultMessage = "The Server has encountered an error.";

        public InternalServerErrorException()
            : base(DefaultMessage)
        {
        }
    }
}