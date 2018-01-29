﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class FullDirectoryTraversal
{
    private static Dictionary<string, List<KeyValuePair<string, double>>> groupedFilesByExtension = new Dictionary<string, List<KeyValuePair<string, double>>>();

    public static void Main()
    {
        string input = Console.ReadLine();
        List<string> filesindirectory = new List<string>();

        filesindirectory.Add(input);
        filesindirectory.AddRange(Directory.GetDirectories(input, ".", SearchOption.AllDirectories).ToList());
        
        foreach (var path in filesindirectory)
        {
            TraversDirectory(path);
        }

        WriteReport();
    }

    private static void TraversDirectory(string directory)
    {
        string input = directory;

        var files = Directory.GetFiles(input);
        
        foreach (var file in files)
        {
            int indexOfLastSlash = file.LastIndexOf('/');
            string fileName = file.Substring(indexOfLastSlash);
            fileName = fileName.Replace('\\', '/');
            
            int indexOfDot = fileName.LastIndexOf('.');
            string extension = fileName.Substring(indexOfDot);

            double size = new FileInfo(file).Length / (double)1024;

            if (!groupedFilesByExtension.ContainsKey(extension))
            {
                groupedFilesByExtension.Add(extension, new List<KeyValuePair<string, double>>());
            }
            groupedFilesByExtension[extension].Add(new KeyValuePair<string, double>(fileName, size));
        }
    }

    private static void WriteReport()
    {
        var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        var fullFileName = Path.Combine(desktopFolder, "report.txt");
        using (var writer = new StreamWriter(fullFileName))
        {
            foreach (var keyValuePair in groupedFilesByExtension.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                writer.WriteLine(keyValuePair.Key);
                foreach (var valuePair in keyValuePair.Value)
                {
                    writer.WriteLine($"--{valuePair.Key} - {valuePair.Value:0.###}kb");
                }
            }
        }
    }
}