using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Photo_Gallery
{
    public class Megapixels
    {
        double width;
        double height;
        public Megapixels(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public string Orientation()
        {
            if(width > height)
            {
                return " (landscape)";
            }else if(height > width)
            {
                return " (portrait)";
            }
            else
            {
                return " (square)";
            }
        }
        override public string ToString()
        {
            return "" + width + "x" + height + Orientation() ;
        }
    }
    class PhotoGallery
    {
        static int photoNumber;
        static int day, month, year;
        static int hour, minutes;
        static double size;
        Megapixels resolution;

        PhotoGallery(int photoNumber, int day, int month, int year, int hour, int minutes, int size, int width, int height)
        {
            PhotoGallery.photoNumber = photoNumber;
            PhotoGallery.day = day;
            PhotoGallery.month = month;
            PhotoGallery.year = year;
            PhotoGallery.hour = hour;
            PhotoGallery.minutes = minutes;
            PhotoGallery.size = size;
            resolution = new Megapixels(width, height);
        }
        string CalculatSize()
        {
            if(size < 1024)
            {
                return $"{size}B";
            }else if(size > 1024 && size < 1024*1024)
            {
                return $"{size / 1000}KB";
            }else if(size > 1024*1024 && size < 1024 * 1024 * 1024)
            {
                return $"{size/1000000}MB";
            }else if(size > 1024 * 1024 * 1024)
            {
                return $"{size / 1000000000}GB";
            }

            return  "error!";
        }
        public override string ToString()
        {
            return $"Name: DSC_{String.Format("{0:0000}", photoNumber)}.jpg{System.Environment.NewLine}" +
                $"Date Taken: {String.Format("{0:00}", day)}/{String.Format("{0:00}", month)}/{year} {String.Format("{0:00}", hour)}:{String.Format("{0:00}",minutes)}{System.Environment.NewLine}" +
                $"Size: {CalculatSize()}{System.Environment.NewLine}" +
                $"Resolution: {resolution.ToString()}";
        }

        static void Main(string[] args)
        {
            PhotoGallery photo = new PhotoGallery(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine(photo.ToString());
        }
    }
}
