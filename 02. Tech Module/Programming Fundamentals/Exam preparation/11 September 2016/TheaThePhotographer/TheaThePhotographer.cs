using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaThePhotographer
{
    class TheaThePhotographer
    {
        static void Main(string[] args)
        {
            int amountOfPictures = int.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadedTime = int.Parse(Console.ReadLine());

            long filteredPicture = (long)Math.Ceiling(amountOfPictures * (filterFactor / 100.0));

            long filteredTime = (long)amountOfPictures * filterTime;
            long uploadingTime = filteredPicture * uploadedTime;
            long totalTime = filteredTime + (long)uploadingTime;


            long seconds = totalTime % 60;
            long minutes = totalTime / 60 % 60;
            long hours = totalTime / 60 / 60 % 24;
            long days = totalTime / 60 / 60 / 24;

            Console.WriteLine($"{days}:{hours:00}:{minutes:00}:{seconds:00}");
        }
    }
}
