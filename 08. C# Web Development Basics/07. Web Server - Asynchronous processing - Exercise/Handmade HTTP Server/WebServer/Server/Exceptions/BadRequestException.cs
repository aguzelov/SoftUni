using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Server.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string InvalidRequestMessage = "Invalid request line";

        public static object ThrowFromInvalidRequest() => throw new BadRequestException(InvalidRequestMessage);

        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}