using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        private static void Main()
        {
            //File file = new File("fileName",10,10);
            Music music = new Music("artist", "album", 10, 10);
            StreamProgressInfo streamProgressInfo = new StreamProgressInfo(music);

            Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());
        }
    }
}