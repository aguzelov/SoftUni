using System;
using System.IO;
using Twitter.Contracts;

namespace Twitter.IO
{
    public class ServerWriter : IWriter
    {
        private const string ServerFileName = "Server.txt";
        private const string MessageSeparator = "<|>";

        private readonly string serverFullPath =
            Path.Combine(Environment.CurrentDirectory, ServerFileName);

        public ServerWriter()
        {
        }

        public void WriteMessage(string message)
        {
            File.AppendAllText(this.serverFullPath, $"{message}{MessageSeparator}");
        }
    }
}