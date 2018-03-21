using System.IO;

namespace Logging
{
    public class LogFile
    {
        private string path = "..\\..\\..\\..\\log.txt";

        public LogFile()
        {
        }

        public int Size { get; set; }

        public void Write(string text)
        {
            using (StreamWriter writer = new StreamWriter(this.path, true))
            {
                writer.WriteLine(text);
            }

            int size = 0;
            foreach (var c in text)
            {
                if (char.IsLetter(c))
                    size += (int)c;
            }

            this.Size += size;
        }
    }
}