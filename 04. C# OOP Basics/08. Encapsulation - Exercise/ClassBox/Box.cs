public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public double SurfaceArea()
    {
        return (length * width) * 2 + (length * height) * 2 + (width * height) * 2;
    }

    public double LateralSurfaceArea()
    {
        return (length * height) * 2 + (width * height) * 2;
    }

    public double Volume()
    {
        return length * width * height;
    }
}