using System;
using System.IO;

public class CopyBinaryFile
{
    public static void Main()
    {
        using (FileStream stream = File.OpenRead("input.gif"))
        using (FileStream writeStream = File.OpenWrite("output.gif"))
        {
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(writeStream);
            
            byte[] buffer = new Byte[1024];
            int bytesRead;
            
            while ((bytesRead = stream.Read(buffer, 0, 1024)) > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
            }
        }
    }
}
