using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

public class ZippingSlicedFiles
{
    private static List<string> files = new List<string>();

    public static void Main()
    {
        string source = "sliceMe.mp4";
        int dotIndex = source.LastIndexOf('.');
        string fileExtension = source.Substring(dotIndex);
        string outputFileName = "assembled"+fileExtension;
        
        string destination = "../../";
        
        int parts = int.Parse(Console.ReadLine());

        Slice(destination + source, destination, parts);
        
        Assemble(files, destination + outputFileName);

    }

    private static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        using (var source = new FileStream(sourceFile, FileMode.Open))
        {
            int fileLength = (int)(source.Length / parts);
            byte[] buffer = new byte[fileLength];
            
            for (int i = 0; i < parts; i++)
            {
                string file = destinationDirectory + "Part-" + i + ".gz";
                using (var destination = new FileStream(file, FileMode.CreateNew))
                {
                    int readBytes = source.Read(buffer, 0, fileLength);

                    using (GZipStream output = new GZipStream(destination,
                        CompressionMode.Compress))
                    {
                        output.Write(buffer, 0, buffer.Length);
                    }

                    if (readBytes == 0)
                    {
                        break;
                    }
                    
                    files.Add(file);
                }
            }
        }
    }

    private static void Assemble(List<string> files, string destinationDirectory)
    {
        using (var destination = new FileStream(destinationDirectory, FileMode.OpenOrCreate))
        {
            for (int i = 0; i < files.Count; i++)
            {
                using (var source = new FileStream(files[i], FileMode.Open))
                {
                    byte[] buffer = new byte[4069];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
