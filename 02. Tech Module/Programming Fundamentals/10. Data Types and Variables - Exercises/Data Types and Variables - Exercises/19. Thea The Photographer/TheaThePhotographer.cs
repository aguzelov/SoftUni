using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Thea_The_Photographer
{
    class TheaThePhotographer
    {
        static void Main(string[] args)
        {
            long totalPuctures = int.Parse(Console.ReadLine());
            long filterTime = int.Parse(Console.ReadLine());
            double filterFactor = int.Parse(Console.ReadLine());
            long uploadTime = int.Parse(Console.ReadLine());

            double usefulPictures = totalPuctures * (filterFactor / 100);
            
            long totalTime = (totalPuctures * filterTime) + ((int)Math.Ceiling(usefulPictures)) * uploadTime;

            long seconds = totalTime % 60;
            long minutes = (totalTime/60)%60;
            long hours = ((totalTime / 60)/60)%24;
            long days = ((totalTime / 60) / 60)/24;

            Console.WriteLine($"{days}:{String.Format("{0:00}",hours)}:{String.Format("{0:00}", minutes)}:{String.Format("{0:00}", seconds)}");
        }
    }
}
