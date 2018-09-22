using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.SliceFile
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var fileName = Console.ReadLine();
            var destination = Console.ReadLine();
            int pieces = int.Parse(Console.ReadLine());

            SliceAsync(fileName, destination, pieces);

            Console.WriteLine("Anything else?");
            while (true)
            {
                if (Console.ReadLine() == "end") break;
            }
        }

        private static void SliceAsync(string sourceFile, string destination, int parts)
        {
            Task.Run(() =>
            {
                Slice(sourceFile, destination, parts);
            });
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);

                long partLength = (source.Length / parts) + 1;
                long currentByte = 0;

                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    string filePath = string.Format("{0}/Part-{1}{2}", destinationPath, currentPart, fileInfo.Extension);

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[partLength];
                        while (currentByte <= partLength * currentPart)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }
                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
                Console.WriteLine("Slice complete.");
            }
        }
    }
}