using System;
using System.IO;

namespace ResultWriter
{
    public static class FileWriter
    {
        private const string path = @"..\..\..\..\result.txt";

        private static bool append = false;

        public static void WriteLine(string text)
        {
            using (StreamWriter writer = new StreamWriter(path, append))
            {
                writer.WriteLine(text);
            }

            append = true;
        }
    }
}