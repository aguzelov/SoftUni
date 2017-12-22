using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.BeerKegs
{
    class BeerKegs
    {
        static List<Keg> kegs = new List<Keg>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                kegs.Add(new Keg(Console.ReadLine(), double.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
            }

             List<Keg> sortedKegList = kegs.OrderBy(v => v.Volume).ToList();

            Console.WriteLine(sortedKegList[sortedKegList.Count-1].Model);
        }
    }
    class Keg
    {
        private string model;
        private double radius;
        private int height;
        private double volume;
        public Keg(string model, double radius, int height)
        {
            this.model = model;
            this.radius = radius;
            this.height = height;
            this.volume = Math.PI * Math.Pow(radius, 2) * height;
        }

        public string Model { get => model; set => model = value; }
        public double Radius { get => radius; set => radius = value; }
        public int Height { get => height; set => height = value; }
        public double Volume { get => volume; set => volume = value; }

    }
}
