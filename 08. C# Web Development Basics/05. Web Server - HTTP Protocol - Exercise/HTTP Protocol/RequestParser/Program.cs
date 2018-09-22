using System;
using System.Collections.Generic;

namespace RequestParser
{
    public class Program
    {
        private static readonly string responseTemplate = "HTTP/1.1 {0}" + Environment.NewLine +
                                                          "Content-Length: {1}" + Environment.NewLine +
                                                          "Content-Type: text/plain" + Environment.NewLine +
                                                          Environment.NewLine +
                                                          "{2}";

        public static void Main(string[] args)
        {
            var validPaths = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var inputParts = input.Split("/", StringSplitOptions.RemoveEmptyEntries);
                var path = "/" + inputParts[0];
                var method = inputParts[1];

                if (!validPaths.ContainsKey(path))
                {
                    validPaths.Add(path, new HashSet<string>());
                }
                validPaths[path].Add(method);
            }

            var requestInput = Console.ReadLine();
            var requestParts = requestInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var requestMethod = requestParts[0];
            var requestPath = requestParts[1];
            var requestProtocol = requestParts[2];

            var statusCode = 0;
            var statusText = string.Empty;

            if (validPaths.ContainsKey(requestPath) && validPaths[requestPath].Contains(requestMethod.ToLower()))
            {
                statusCode = 200;
                statusText = "OK";
            }
            else
            {
                statusCode = 400;
                statusText = "Not Found";
            }

            Console.WriteLine(string.Format(responseTemplate, statusCode + " " + statusText, statusText.Length, statusText));
        }
    }
}