using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    private double Length
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    private double Width
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    private double Height
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
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