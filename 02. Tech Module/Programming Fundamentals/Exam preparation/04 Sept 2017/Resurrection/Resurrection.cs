using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resurrection
{
    class Resurrection
    {
        static void Main(string[] args)
        {
            int amountOFPhoenixes = int.Parse(Console.ReadLine());

            List<Phoenix> phoenixes = new List<Phoenix>();

            for (int i = 0; i < amountOFPhoenixes; i++)
            {
                int length = int.Parse(Console.ReadLine());
                decimal width = decimal.Parse(Console.ReadLine());
                int wingLength = int.Parse(Console.ReadLine());

                phoenixes.Add(new Phoenix(length, width, wingLength));
            }

            phoenixes.ForEach(x => x.Print());
        }
    }
    class Phoenix
    {
        private static int counter = 0;

        private string name;

        private int length;
        private decimal width;
        private int wingLength;

        private decimal yearsForReincarnate;

        public Phoenix(int length, decimal width, int wingLength)
        {
            this.length = length;
            this.width = width;
            this.wingLength = wingLength;

            counter++;
            this.name = "P" + counter;

            CalculateReincarneteYears();
        }

        public int Length { get => length; set => length = value; }
        public decimal Width { get => width; set => width = value; }
        public int WingLength { get => wingLength; set => wingLength = value; }

        private void CalculateReincarneteYears()
        {
            yearsForReincarnate = (decimal)Math.Pow(length, 2) * (width + (2 * (decimal)wingLength));
        }
        public void Print()
        {
            Console.WriteLine($"{this.yearsForReincarnate}");
        }
    }
}
