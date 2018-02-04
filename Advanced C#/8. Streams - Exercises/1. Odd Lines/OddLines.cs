using System;
using System.IO;
using System.Text;

public class OddLines
{
    public static void Main()
    {
        string fileName = "../../text.txt";

        const Int32 bufferSize = 128;
        using (var fileStream = File.OpenRead(fileName))
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
        {
            string line;
            int lineNumber = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (lineNumber % 2 != 0)
                {
                    Console.WriteLine(line);
                }

                lineNumber++;
            }
        }
    }
}
