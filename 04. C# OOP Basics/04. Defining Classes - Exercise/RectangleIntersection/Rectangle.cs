public class Rectangle
{
    public string ID { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public Point TopLeft { get; set; }

    public Rectangle(string iD, double width, double height, Point topLeft)
    {
        ID = iD;
        Width = width;
        Height = height;
        TopLeft = topLeft;

    }

    public bool IsIntersectWith(Rectangle other)
    {
        return other.TopLeft.X + other.Width >= this.TopLeft.X &&
               other.TopLeft.X <= this.TopLeft.X + this.Width &&
               other.TopLeft.Y >= this.TopLeft.Y - this.Height &&
               other.TopLeft.Y - other.Height <= this.TopLeft.Y;
    }
}