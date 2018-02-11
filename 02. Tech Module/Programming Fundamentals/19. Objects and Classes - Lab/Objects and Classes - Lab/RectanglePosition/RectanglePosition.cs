using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectanglePosition
{
    class RectanglePosition
    {
        static void Main(string[] args)
        {
            Rectangle firstRec = new Rectangle();
            Rectangle secondRec = new Rectangle();
            firstRec.Position(secondRec);
        }
    }
    class Rectangle
    {
        private double left;
        private double top;
        private double width;
        private double height;
        private double right;
        private double bottom;

        public Rectangle()
        {
            double[] positions = Console.ReadLine()
                                        .Split(' ')
                                        .Select(double.Parse)
                                        .ToArray();

            this.left = positions[0];
            this.top = positions[1];
            this.width = positions[2];
            this.height = positions[3];
            this.right = left + width;
            this.bottom = top + width;
        }

        public double Left { get => left; set => left = value; }
        public double Top { get => top; set => top = value; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }
        public double Right { get => right; set => right = value; }
        public double Bottom { get => bottom; set => bottom = value; }

        public void Position(Rectangle other)
        {
            if (this.left >= other.left &&
                this.right <= other.right &&
                this.top <= other.top &&
                this.bottom <= other.bottom)
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }
    }
}
