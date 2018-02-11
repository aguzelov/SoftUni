using System.IO;

public class LineNumbers
{
    public static void Main()
    {
        using (var reader = new StreamReader(@"../../text.txt"))
        {
            using (var writer = new StreamWriter(@"../../output.txt", append: false))
            {
                CopyToOutputStream(reader, writer);
            }
        }
        
    }
    private static void CopyToOutputStream(StreamReader inputStream, StreamWriter outputStream)
    {
        string line = null;
        int count = 1;
        while ((line = inputStream.ReadLine()) != null)
        {
            outputStream.WriteLine($"Line {count++}: " + line);
        }
        outputStream.Write(inputStream.ReadToEnd());
    }
}
